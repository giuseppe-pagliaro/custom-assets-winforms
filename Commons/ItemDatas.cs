namespace CustomLists
{
    public class ItemDatas
    {
        public ItemDatas()
        {
            this.Id = 0;
        }

        public ItemDatas(ItemDatas itemDatas)
        {
            this.Id = itemDatas.Id;
        }

        public int? Id { get; set; }
    }
}