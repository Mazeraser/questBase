using Codebase.Services.QuestSystem.Quests;
using Codebase.Services.InventorySystem;
using Codebase.Libraries.Stats;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using UnityEngine;
using System;

namespace Codebase.Services.QuestSystem.QuestTriggers
{
    public class CollectQuestTrigger : QuestTrigger
    {
        public static event Action<ItemStats> ItemUsedEvent;

        private CollectQuest _quest;

        public override void Start()
        {
            base.Start();
            _quest = transform.GetComponentInParent<CollectQuest>();
            BlockSignals.OnBlockStart += Interact;
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
            BlockSignals.OnBlockStart -= Interact;
        }

        public void Interact(Block block)
        {
            if (block.BlockName == _quest.ObjectDialogueName && ItemsCollected())
            {
                Debug.Log("Collect quest has passed");
                PassQuest();
            }
        }

        private bool ItemsCollected()
        {
            Inventory inventory = GameObject.FindAnyObjectByType<Codebase.Services.InventorySystem.Inventory>();//TODO: find object on scene, can invoke bugs

            var collected_items = inventory.InventorySlots.Where(x => _quest.ItemID.Contains(x.ID)).ToArray();
            if(collected_items.Length >= _quest.ItemCount)
            {
                for(int i=0; i< _quest.ItemCount; i++)
                    ItemUsedEvent?.Invoke(collected_items[i]);
                return true;
            }
            return false;
        }
    }
}