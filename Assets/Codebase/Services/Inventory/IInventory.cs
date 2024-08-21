using Codebase.Libraries.Stats;

namespace Codebase.Services.Inventory
{
    interface IInventory
    {
        //work with ItemStats because Item is UI prefab
        ItemStats[] InventorySlots { get; }
        ItemStats selected_item { get; }
        int Selected_Item_Index { get; }
        bool AddItem(ItemStats item);
        void ChangeSelectedItem(int turn);
        bool IsFull { get; }
    }
}