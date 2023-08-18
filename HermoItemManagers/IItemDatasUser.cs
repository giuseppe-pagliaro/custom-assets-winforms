using HermoItemManagers.Managers;

namespace HermoItemManagers
{
    internal interface IItemDatasUser
    {
        void ItemWasEdited(object? sender, ItemEditedEventArgs e);

        void ItemWasDeleted(object? sender, ItemDeletedEventArgs e);
    }
}