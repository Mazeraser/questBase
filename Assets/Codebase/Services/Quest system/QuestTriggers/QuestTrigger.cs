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
        }

        public virtual void Update() { }

        public virtual void OnDestroy()
        {
            BlockSignals.OnBlockStart -= CheckDialogueToActivateQuest;
        }

        [ContextMenu("Got quest")]
        public void GotQuest()
        {
            transform.GetComponentInParent<Quest>().Got();
            //Quest.diary.Add(transform.GetComponentInParent<Quest>());
        }

        [ContextMenu("Pass quest")]
        public void PassQuest()
        {
            transform.GetComponentInParent<Quest>().Pass();
            //Destroy(transform.parent.gameObject);
        }

    }
}