using Codebase.Libraries.Stats;
using Codebase.Services.InventorySystem;
using Codebase.Services.Reward;
using Codebase.Services.QuestSystem.QuestTriggers;
using Codebase.UI.InventoryUI.Items;
using TMPro;
using UnityEngine;
using Zenject;
using System.Linq;

namespace Codebase.UI.InventoryUI
{
    public class InventoryViewModel : MonoBehaviour
    {
        [SerializeField]
        private GameObject _itemPrefab;
        [SerializeField]
        private GameObject _messageItemPrefab; 
        [SerializeField]
        private GameObject _programItemPrefab;

        [SerializeField]
        private TextMeshProUGUI _itemDescriptionTMP;

        [SerializeField]
        private GameObject[] _slots;

        private Inventory _inventory_model;
        private GameplayCanvasEventChecker _gameplayCanvasEventChecker;


        public delegate void ShowInventory();
        public ShowInventory ShowInventoryDelegate;

        [Inject]
        private void Construct(Inventory inventory)
        {
            _inventory_model = inventory;
        }

        private void Start()
        {
            GiveComponent.GiveItemEvent += AddNewItem;
            CollectQuestTrigger.ItemUsedEvent += RemoveItem;
            
            UpdateSlots();
            ResetActiveItem();
        }
        private void OnDestroy()
        {
            GiveComponent.GiveItemEvent -= AddNewItem;
            CollectQuestTrigger.ItemUsedEvent -= RemoveItem;
        }

        private void UpdateSlots()
        {
            ClearItems();
            for (int i = 0; i < Inventory.INVENTORY_SIZE; i++)
            {
                if (i < _inventory_model.InventorySlots.Length)
                {
                    switch ((int)_itemPrefab.GetComponent<Item>().GetItemFromDictionary(_inventory_model.InventorySlots[i].ID).ItemClass)
                    {
                        case 0:
                            _slots[i] = Instantiate(_itemPrefab, transform);
                            _slots[i].GetComponent<Item>().InitItemFromDictionary(_inventory_model.InventorySlots[i].ID);
                            break;
                        case 1:
                            _slots[i] = Instantiate(_messageItemPrefab, transform);
                            _slots[i].GetComponent<MessageItem>().InitItemFromDictionary(_inventory_model.InventorySlots[i].ID);
                            break;
                        case 2:
                            _slots[i] = Instantiate(_programItemPrefab, transform);
                            _slots[i].GetComponent<ProgramItem>().InitItemFromDictionary(_inventory_model.InventorySlots[i].ID);
                            break;
                    }

                    _inventory_model.InventorySlots[i].ItemName = _slots[i].GetComponent<Item>().GetName();
                    _inventory_model.InventorySlots[i].ItemIcon = _slots[i].GetComponent<Item>().GetIcon();
                }
                else
                {
                    if (_slots[i] != null)
                    {
                        Destroy(_slots[i]);
                        _slots[i] = null;
                    }
                }
            }
        }

        public void ChangeActiveItem(int turn)
        {
            if (_inventory_model.InventorySlots.Length>0)
            {
                if(_slots[_inventory_model.Selected_Item_Index]!=null)
                    _slots[_inventory_model.Selected_Item_Index].
                        GetComponent<IItem>().Deactivation();
                _inventory_model.ChangeSelectedItem(turn);
                if (_slots[_inventory_model.Selected_Item_Index] != null)
                {
                    _slots[_inventory_model.Selected_Item_Index].GetComponent<IItem>().Activation();
                    _itemDescriptionTMP.text = _inventory_model.selected_item.ItemName;
                }
            }
        }

        public void GetVariables(GameplayCanvasEventChecker gameplayCanvasEventChecker)
        {
            _gameplayCanvasEventChecker = gameplayCanvasEventChecker;
        }

        public void ResetActiveItem()
        {
            if (_slots[_inventory_model.Selected_Item_Index]!=null)
                _slots[_inventory_model.Selected_Item_Index].
                    GetComponent<Item>().Deactivation();
            _itemDescriptionTMP.text = string.Empty;
        }

        public void AddNewItem(ItemStats newItem, bool showInventory)
        {
            if(_inventory_model.AddItem(newItem))
                UpdateSlots();
            if(showInventory)
                ShowInventoryDelegate?.Invoke();
        }

        private bool InventoryContains(ItemStats[] items)
        {
            int[] items_name = new int[items.Length];
            int[] inventory_items_name = new int[_inventory_model.InventorySlots.Length];

            for (int i = 0; i < items.Length; i++)
                items_name[i] = items[i].ID;
            for (int j = 0; j < _inventory_model.InventorySlots.Length; j++)
                inventory_items_name[j] = _inventory_model.InventorySlots[j].ID;

            return !items_name.Except(inventory_items_name).Any();
        }

        private void RemoveItem(ItemStats item)
        {
            for(int i=0;i<_inventory_model.InventorySlots.Length;i++)
            {
                if (_inventory_model.InventorySlots[i].ID == item.ID)
                {
                    _inventory_model.RemoveItem(i);
                }
            }
            UpdateSlots();
        }

        private void ClearItems()
        {
            foreach(GameObject item in _slots)
            {
                if (item != null)
                    Destroy(item);
            }
        }

        public void UseItem()
        {
            if (_slots[_inventory_model.Selected_Item_Index] != null)
                _slots[_inventory_model.Selected_Item_Index].
                    GetComponent<Item>().Use();
        }
    }
}