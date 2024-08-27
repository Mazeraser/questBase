using Codebase.Libraries.Stats;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Codebase.Services.InventorySystem
{
    public class Inventory : MonoBehaviour, IInventory
    {
        [SerializeField]private ItemStats[] _inventory_slots = new ItemStats[INVENTORY_SIZE];

        public Action ItemAddedEvent;

        public ItemStats[] InventorySlots
        {
            get
            {
                List<ItemStats> items = new List<ItemStats>();
                for(int i=0;i<_inventory_slots.Length;i++)
                {
                    if (_inventory_slots[i] != null)
                        items.Add(_inventory_slots[i]);
                    else
                        break;
                }
                return items.ToArray();
            }
            set
            {
                _inventory_slots = value;
            }
        }
        public int[] InventoryIDs
        {
            get
            {
                List<int> items = new List<int>();
                for (int i = 0; i < _inventory_slots.Length; i++)
                {
                    if (_inventory_slots[i] != null)
                    {
                        items.Add(_inventory_slots[i].ID);
                    }
                    else
                        break;
                }
                return items.ToArray();
            }
            set
            {
                _inventory_slots = new ItemStats[_inventory_slots.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    AddItem(new ItemStats("", null, value[i]));
                }
            }
        }

        public const int INVENTORY_SIZE = 6;

        private int _selectedItemIndex;
        public int Selected_Item_Index{ get { return _selectedItemIndex; } }

        public ItemStats selected_item{get{return _selectedItemIndex>=0 ? _inventory_slots[_selectedItemIndex]:null;}}

        public bool AddItem(ItemStats item) 
        {
            for(int i=0;i<INVENTORY_SIZE;i++)
            {
                if (_inventory_slots[i] == null)
                {
                    _inventory_slots[i] = item;
                    ItemAddedEvent?.Invoke();
                    return true;
                }
            }
            return false;
        }
        public bool IsFull
        {
            get
            {
                for (int i = 0; i < INVENTORY_SIZE; i++)
                {
                    if (_inventory_slots[i] == null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public void ChangeSelectedItem(int turn)
        {
            int value = Mathf.Clamp(_selectedItemIndex + turn, 0, INVENTORY_SIZE-1);
            SetSelectedItem(value>=InventorySlots.Length ? _selectedItemIndex : value);
        }

        public void SetSelectedItem(int index)
        {
            _selectedItemIndex = index;
        }
        public void RemoveItem(int index)
        {
            for (int i = 0; i < INVENTORY_SIZE; i++)
            {
                if (i >= index && i < INVENTORY_SIZE - 1)
                    _inventory_slots[i] = _inventory_slots[i + 1];
            }
        }
    }
}