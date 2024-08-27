using Codebase.Services.InventorySystem;
using System.Linq;
using Zenject;

namespace Codebase.Services.Gate
{
    public class ItemGate : GateParent<int>
    {
        private IInventory _inventory;


        [Inject]
        private void Construct(IInventory inventory)
        {
            _inventory = inventory;
        }

        private void Update()
        {
            var inventoryItems = _inventory.InventorySlots.ToList().Select(p => p.ID);

            bool flag = false;
            foreach(int itemID in _requiredItems)
            {
                if (inventoryItems.Contains(itemID))
                {
                    flag = true;
                    continue;
                }
                flag = false;
                break;
            }
            if (flag)
                OpenGate();
        }
    }
}