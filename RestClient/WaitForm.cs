using Commons;

namespace RestClient
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();

            loadingMessage = "Loading";
            animationRunning = true;
            worker = null;
            style = new();

            CenterToParent();
        }

        public WaitForm(Action worker) : this()
        {
            this.worker = worker;
        }

        private String loadingMessage;
        private bool animationRunning;
        private Action? worker;

        private Style style;

        #region Properties

        public String LoadingMessage
        {
            get { return loadingMessage; }
            set { loadingMessage = value; }
        }

        public Style Style
        {
            get { return style; }
            set
            {
                style = value;

                Style.Apply(this, style, BgType.Primary);
                Style.Apply(txtLoading, style, FontStyle.Bold);
            }
        }

        #endregion

        private void UpdateLoadingMessageSafely(String text)
        {
            if (animationRunning == false)
            {
                return;
            }

            if (txtLoading.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateLoadingMessageSafely(text); };
                txtLoading.Invoke(safeWrite);
            }
            else
            {
                txtLoading.Text = text;
            }
        }

        private void ExecutePointsAnimation()
        {
            short numPoints = 3;
            short sleepingTimeInMs = 500;

            while (animationRunning)
            {
                Thread.Sleep(sleepingTimeInMs);

                switch (numPoints)
                {
                    case 3:
                        numPoints = 0;
                        break;

                    case 2:
                        numPoints = 3;
                        break;

                    case 1:
                        numPoints = 2;
                        break;

                    case 0:
                        numPoints = 1;
                        break;

                    default:
                        numPoints = 0;
                        break;
                }

                String loadingMessage = this.loadingMessage;

                for (int i = 0; i < numPoints; i++)
                {
                    loadingMessage += ".";
                }

                var threadParameters = new ThreadStart(delegate { UpdateLoadingMessageSafely(loadingMessage); });
                Thread threadUpdateLoadingMessage = new(threadParameters);
                threadUpdateLoadingMessage.Start();
            }
        }

        #region Event Consumers

        private void WaitForm_Load(object sender, EventArgs e)
        {
            if (worker is not null)
            {
                Thread threadPointsAnimation = new(new ThreadStart(ExecutePointsAnimation))
                {
                    IsBackground = true
                };
                threadPointsAnimation.Start();

                Task.Factory.StartNew(worker).ContinueWith(t => { Close(); },
                    TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                MessageBox.Show("A null task was started.");
                Close();
            }
        }

        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            animationRunning = false;
        }

        #endregion
    }
}