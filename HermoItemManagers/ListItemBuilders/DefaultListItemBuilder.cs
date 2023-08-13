namespace HermoItemManagers.ListItemBuilders
{
    /// <summary>
    /// Uses the "ToString" method of any given Class to create a ListItem.
    /// </summary>
    public class DefaultListItemBuilder : ListItemBuilder<DefaultListItemBuilder>
    {
        private DefaultListItemBuilder()
        {
        }

        public override void Populate(ListItem listItem)
        {
            throw new NotImplementedException();
        }

        public override void ApplyStyle(ListItem listItem)
        {
            throw new NotImplementedException();
        }

        public override void ListItemClickedAction(ListItem listItem)
        {
            throw new NotImplementedException();
        }
    }
}