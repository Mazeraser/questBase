using Codebase.Libraries.Stats;
using System;
using UnityEngine;

namespace Codebase.UI.InventoryUI.Items
{
    public class MessageItem : Item
    {
        public static Action<string> ReadMessageEvent;

        [SerializeField]
        private string _messageText;
        public string GetMessage()
        {
            return _messageText;
        }

        public override void InitItemFromDictionary(int id)
        {
            base.InitItemFromDictionary(id);
            foreach (MessageItem item in ItemLibrary.MessageItems)
            {
                if (item.GetID() == id)
                {
                    _messageText = item.GetMessage();
                }
            }
        }
        public override void Use()
        {
            ReadMessageEvent?.Invoke(_messageText);
        }
    }
}
