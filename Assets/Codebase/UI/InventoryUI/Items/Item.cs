using Codebase.Libraries;
using Codebase.Libraries.Stats;
using UnityEngine;
using UnityEngine.UI;
using Codebase.UI.InventoryUI;
using System;
using Codebase.Services.Reward;

namespace Codebase.UI.InventoryUI.Items
{
    public class Item : MonoBehaviour, IItem
    {
        public ItemLibrary ItemLibrary;

        public Image Background;

        [SerializeField]
        protected string _itemName;
        [SerializeField]
        protected Image _itemIcon;

        [SerializeField]
        protected int _itemID;

        public Color NewBackgroundColor;

        private Color _initialColor;
        void Start()
        {
            _initialColor = Background.color;
        }

        public virtual void InitItemFromDictionary(int id)
        {
            foreach (ItemStats itemStats in ItemLibrary.ItemStats)
            {
                if (itemStats.ID == id)
                {
                    _itemName = itemStats.ItemName;
                    _itemIcon.sprite = itemStats.ItemIcon;
                    _itemIcon.color = new Color(255, 255, 255, 255);
                    _itemID = itemStats.ID;
                }
            }
        }
        public ItemStats GetItemFromDictionary(int id)
        {
            foreach (ItemStats itemStats in ItemLibrary.ItemStats)
            {
                if (itemStats.ID == id)
                {
                    return itemStats;
                }
            }
            return new ItemStats("",null,0);
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
        public Sprite GetIcon()
        {
            return _itemIcon.sprite;
        }

        public virtual void Use()
        {
            Debug.Log("Using item...");
        }
    }
}