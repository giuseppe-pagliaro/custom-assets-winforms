using Commons;

namespace RestClient
{
    public partial class WaitForm : Form
    {
        public WaitForm()
        {
            InitializeComponent();

            this.loadingMessage = "Loading";
            this.animationRunning = true;
            this.worker = null;
            this.style = new();

            // TODO fix (Parent is always null?)
            if (Parent is not null)
            {
                int x = this.Parent.Location.X + this.Parent.Width / 2 - this.Width / 2;
                int y = this.Parent.Location.Y + this.Parent.Height / 2 - this.Height / 2;
                this.Location = new(x, y);
            }
        }

        public WaitForm(Action worker) : this()
        {
            this.worker = worker;
        }

        private String loadingMessage;
        private bool animationRunning;
        private Action? worker;

        private Style style;

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

                StyleAppliers.PrimaryBg(this, style);
                StyleAppliers.Label(this.txtLoading, style, FontStyle.Bold);
            }
        }

        private void UpdateLoadingMessageSafely(String text)
        {
            if (this.animationRunning == false)
            {
                return;
            }

            if (this.txtLoading.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateLoadingMessageSafely(text); };
                this.txtLoading.Invoke(safeWrite);
            }
            else
            {
                this.txtLoading.Text = text;
            }
        }

        private void ExecutePointsAnimation()
        {
            short numPoints = 3;
            short sleepingTimeInMs = 500;

            while (this.animationRunning)
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

        private void WaitForm_Load(object sender, EventArgs e)
        {
            if (this.worker is not null)
            {
                Thread threadPointsAnimation = new(new ThreadStart(ExecutePointsAnimation));
                threadPointsAnimation.IsBackground = true;
                threadPointsAnimation.Start();

                Task.Factory.StartNew(this.worker).ContinueWith(t => { this.Close(); },
                    TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {
                MessageBox.Show("A null task was started.");
                this.Close();
            }
        }

        private void WaitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.animationRunning = false;
        }
    }
}