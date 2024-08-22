using System;
using UnityEngine;

namespace Codebase.Services.QuestSystem.Quests
{
    public abstract class Quest : MonoBehaviour
    {
        public static Action<Quest> QuestGotEvent;
        public static Action<Quest> QuestPassedEvent;

        protected string _questName;
        public string QuestName
        {
            get => _questName;
        }

        protected string _questDescription;
        public string QuestDescription
        {
            get => _questDescription;
        }

        protected string _questStarterName;
        public string QuestStarterName
        {
            get => _questStarterName;
        }

        protected int _startItemID;
        public int StartItemID
        {
            get => _startItemID;
        }

        protected int _rewardID;
        public int RewardID
        {
            get => _rewardID;
        }

        [SerializeField]
        private bool _hasGotFlag;
        [SerializeField]
        private bool _hasPassedFlag;
        public bool HasPassed {  get { return _hasPassedFlag; } }

        public virtual void Pass()
        {
            _hasPassedFlag = true;
            QuestPassedEvent?.Invoke(this);
        }
        public virtual void Got()
        {
            if (!_hasGotFlag)
            {
                _hasGotFlag = true;
                QuestGotEvent?.Invoke(this);
            }
        }
        public virtual void Start() 
        {
            //TODO: Add check on quest registry for quest existing
        }
        public virtual void Destroy() { }

        public virtual void SetTypeToTrigger(GameObject trigger)
        {
            Debug.Log("base");
        }
        
        public Quest(string name, string description, string questStarterName, int startItemID, int itemID)
        {
            _questName = name;
            _questDescription = description;
            _questStarterName = questStarterName;
            _startItemID = startItemID;
            _rewardID = itemID;
        }
        public virtual void Copy(string name, string description, string questStarterName, int startItemID, int itemID, string[] settings)
        {
            _questName = name;
            _questDescription = description;
            _questStarterName = questStarterName;
            _startItemID = startItemID;
            _rewardID = itemID;
        }
    }
}