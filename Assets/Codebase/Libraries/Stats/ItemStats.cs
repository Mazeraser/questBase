using System;
using UnityEngine;

namespace Codebase.Libraries.Stats
{
    [Serializable]
    public class ItemStats
    {
        public enum ItemType
        {
            Regular=0,
            Message=1,
            Programm=2,
        }

        public ItemType ItemClass;
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