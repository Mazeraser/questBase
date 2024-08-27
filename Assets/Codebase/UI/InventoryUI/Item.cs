using Codebase.Libraries;
using Codebase.Libraries.Stats;
using UnityEngine;
using UnityEngine.UI;
using Codebase.UI.InventoryUI;
using System;
using Codebase.Services.Reward;

namespace Codebase.UI
{
    public class Item : MonoBehaviour
    {
        public ItemLibrary ItemLibrary;

        public Image Background;

        [SerializeField]
        private string _itemName;
        [SerializeField]
        private Image _itemIcon;

        [SerializeField]
        private int _itemID;

        public Color NewBackgroundColor;

        private Color _initialColor;
        // private InventoryItemContainer _inventoryItemContainer;

        private bool _isInitialized;
        public bool IsInitialized
        {
            get { return _isInitialized; }
        }

        void Start()
        {
            _isInitialized = false;
            _initialColor = Background.color;

            /*_inventoryItemContainer = FindObjectOfType<InventoryItemContainer>();
            
            _inventoryItemContainer.AddNewItem(this);*/
        }

        public void InitItemFromDictionary(int id)
        {

            if (name == null)
            {
                return;
            }
            
            foreach (ItemStats itemStats in ItemLibrary.ItemStats)
            {
                if (itemStats.ID == id)
                {
                    _itemName = itemStats.ItemName;
                    _itemIcon.sprite = itemStats.ItemIcon;
                    _itemIcon.color = new Color(255, 255, 255, 255);
                    _itemID = itemStats.ID;

                    _isInitialized = true;
                }
            }
        }

        public void Activation()
        {
            Background.color = NewBackgroundColor;
        }

        public void Deactivation()
        {
            Background.color = _initialColor;
        }
        
        public string GetName()
        {
            return _itemName;
        }

        public int GetID()
        {
            return _itemID;
        }

        
        public void SetSprite(Sprite itemSprite)
        {
            _itemIcon.GetComponent<Image>().sprite = itemSprite;
        }

        public void SetName(string itemName)
        {
            _itemName = itemName;
        }

        public void SetID(int itemID)
        {
            _itemID = itemID;
        }
        // new functions
        public Sprite GetIcon() 
        {
            return _itemIcon.sprite;
        }

        public void Clear()
        {
            _isInitialized = false;
            _itemName = "";
            _itemIcon.color = new Color(255,255,255,0);
            _itemID = -1;
        }
    }
}