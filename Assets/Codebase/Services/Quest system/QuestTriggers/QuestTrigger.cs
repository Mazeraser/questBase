using UnityEngine;
using Codebase.Services.QuestSystem.Quests;
using Fungus;

namespace Codebase.Services.QuestSystem.QuestTriggers
{
    public abstract class QuestTrigger : MonoBehaviour
    {
        public virtual void CheckDialogueToActivateQuest(Block block)
        {
            Quest quest = transform.GetComponentInParent<Quest>();
            if (block.BlockName==quest.QuestStarterName)
            {
                GotQuest();
            }
        }

        public virtual void Start() 
        {
            BlockSignals.OnBlockStart += CheckDialogueToActivateQuest;
            Quest.StartNextQuest += StartNextStage;
        }

        public virtual void Update() { }

        public virtual void OnDestroy()
        {
            BlockSignals.OnBlockStart -= CheckDialogueToActivateQuest;
            Quest.StartNextQuest -= StartNextStage;
        }

        [ContextMenu("Got quest")]
        public void GotQuest()
        {
            transform.GetComponentInParent<Quest>().Got();
        }

        [ContextMenu("Pass quest")]
        public void PassQuest()
        {
            transform.GetComponentInParent<Quest>().Pass();
        }

        private void StartNextStage(string questName)
        {
            if (questName == transform.GetComponentInParent<Quest>().QuestName)
                GotQuest();
        }

    }
}