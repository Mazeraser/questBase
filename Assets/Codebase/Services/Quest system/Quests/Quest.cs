using Codebase.Services.DiarySystem;
using DG.Tweening;
using System;
using System.Linq;
using UnityEngine;

namespace Codebase.Services.QuestSystem.Quests
{
    [Serializable]
    public class QuestData
    {
        public string FilePath="";
        public string QuestName="";
        public bool HasPassed=false;
    }

    public abstract class Quest : MonoBehaviour
    {
        public static Action<Quest> QuestGotEvent;
        public static Action<Quest> QuestPassedEvent;
        public static Action<string> StartNextQuest;

        public string FilePath = "";

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

        protected string _nextQuestName;
        public string NextQuestName
        {
            get => _nextQuestName;
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
            if (_nextQuestName != "")
                StartNextQuest?.Invoke(_nextQuestName);
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
            if (DiaryQuest.Instance.QuestDatas.ToList().Any(quest => quest.QuestName == GetComponentInParent<Quest>().QuestName))
            {
                if(DiaryQuest.Instance.Get().ToList().Any(quest => quest.QuestName == GetComponentInParent<Quest>().QuestName)) //for bypass duplicate
                {
                    Destroy(gameObject);
                }
                else
                {
                    Got();
                    if (DiaryQuest.Instance.QuestDatas.ToList().First(quest => quest.QuestName == GetComponentInParent<Quest>().QuestName).HasPassed)
                        Pass();
                }
            }
        }

        public virtual void SetTypeToTrigger(GameObject trigger)
        {
            Debug.Log("base");
        }
        
        public Quest(string filePath, string name, string description, string questStarterName, int startItemID, int itemID, string nextQuestName)
        {
            FilePath = filePath;
            _questName = name;
            _questDescription = description;
            _questStarterName = questStarterName;
            _startItemID = startItemID;
            _rewardID = itemID;
            _nextQuestName = nextQuestName;
        }
        public virtual void Copy(string filePath, string name, string description, string questStarterName, int startItemID, int itemID, string nextQuestName, string[] settings)
        {
            FilePath = filePath;
            _questName = name;
            _questDescription = description;
            _questStarterName = questStarterName;
            _startItemID = startItemID;
            _rewardID = itemID;
            _nextQuestName = nextQuestName;
        }
    }
}