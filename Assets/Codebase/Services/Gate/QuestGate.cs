using Codebase.Services.QuestSystem.Quests;
using UnityEngine;

namespace Codebase.Services.Gate
{
    public class QuestGate : GateParent<string>
    {
        private int _completedQuestCount=0;

        private void Start()
        {
            Quest.QuestPassedEvent += CatchQuest;
        }
        private void OnDestroy()
        {
            Quest.QuestPassedEvent -= CatchQuest;
        }

        private void Update()
        {
            if (_completedQuestCount == _requiredItems.Length)
            {
                OpenGate();
            }
        }

        protected void CatchQuest(Quest quest)
        {
            foreach (var name in _requiredItems)
            {
                if (name == quest.QuestName)
                {
                    _completedQuestCount++;
                }
            }
        }

        
    }
}