using System;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase.Libraries.Stats
{
    [Serializable]
    public class ItemStats
    {
        public string ItemName;
        public Sprite ItemIcon;
        public int ID;

        public ItemStats(string itemName, Sprite itemIcon, int id)
        {
            ItemName = itemName;
            ItemIcon = itemIcon;
            ID = id;
        }
    }
}