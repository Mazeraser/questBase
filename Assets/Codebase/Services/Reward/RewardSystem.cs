using Codebase.Triggers;
using UnityEngine;

namespace Codebase.Services.Reward
{
    public class RewardSystem : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);

            //Quest.QuestGotEvent += CatchQuest;
            //Quest.QuestPassedEvent += CatchQuest;
            TriggerInteractionGetItem.ItemGotEvent += GiveItemOnID;
        }
        private void OnDestroy()
        {
            //Quest.QuestGotEvent -= CatchQuest;
            //Quest.QuestPassedEvent -= CatchQuest; 
            TriggerInteractionGetItem.ItemGotEvent -= GiveItemOnID;
        }

        private void GiveItemOnID(int ID, bool showInventory)
        {
            GetComponent<IDConverter>().Convert(ID, showInventory);
        }
    }
}
