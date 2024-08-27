using Codebase.Triggers;
using Codebase.Services.QuestSystem.Quests;
using UnityEngine;

namespace Codebase.Services.Reward
{
    public class RewardSystem : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);

            Quest.QuestGotEvent += CatchQuest;
            Quest.QuestPassedEvent += CatchQuest;
            TriggerInteractionGetItem.ItemGotEvent += GiveItemOnID;
        }
        private void OnDestroy()
        {
            Quest.QuestGotEvent -= CatchQuest;
            Quest.QuestPassedEvent -= CatchQuest; 
            TriggerInteractionGetItem.ItemGotEvent -= GiveItemOnID;
        }

        private void CatchQuest(Quest quest)
        {
            GetComponent<IDConverter>().Convert(quest.HasPassed ? quest.RewardID : quest.StartItemID, false);
        }
        private void GiveItemOnID(int ID, bool showInventory)
        {
            GetComponent<IDConverter>().Convert(ID, showInventory);
        }
        private void LoadItemsData(int[] IDs)
        {
            foreach (int ID in IDs)
                GiveItemOnID(ID, false);
        }
    }
}
