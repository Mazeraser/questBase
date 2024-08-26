using Fungus;
using Codebase.Services.QuestSystem.Quests;
using UnityEngine;

namespace Codebase.Services.QuestSystem.QuestTriggers
{
    public class DialogueQuestTrigger : QuestTrigger
    {
        private DialogueQuest _quest;

        public override void Start()
        {
            base.Start();
            _quest = transform.GetComponentInParent<DialogueQuest>();

            BlockSignals.OnBlockStart += Interact;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            BlockSignals.OnBlockStart -= Interact;
        }

        public void Interact(Block block)
        {
            if (block.BlockName == _quest.EndMessageName)
            {
                PassQuest();
            }
        }
    }
}
