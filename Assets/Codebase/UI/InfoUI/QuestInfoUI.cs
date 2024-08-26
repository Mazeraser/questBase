using Codebase.Services.QuestSystem.Quests;
using Codebase.UI.InfoUI;
using UnityEngine;
using TMPro;

namespace Codespace.UI.InfoUI
{
    public class QuestInfoUI : MonoBehaviour, IInfoUI<Quest>
    {
        [SerializeField]
        private TMP_Text _header; 

        private Quest _quest;
        public Quest ObjectQuest { get { return _quest; } }

        public void SetInfoObject(Quest obj) 
        {
            _quest = obj;
            _header.text = obj.QuestName;
            //_description.text = obj.QuestDescription;
        }

        private void Start()
        {
            Quest.QuestPassedEvent += CatchQuest;
        }
        private void OnDestroy()
        {
            Quest.QuestPassedEvent -= CatchQuest;
        }

        private void CatchQuest(Quest quest)
        {
            if (_quest.QuestName == quest.QuestName)
            {
                _header.text = "<s>" + _header.text + "</s>";
            }
        }
    }
}