using HermoCommons;

namespace HermoItemManagers
{
    public interface IListItem
    {
        static readonly int INITIAL_HEIGHT;

        ItemDatas Item { get; set; }

        Style Style { get; set; }

        Type ViewerType { get; set; }
        Type EditorType { get; set; }
    }
}