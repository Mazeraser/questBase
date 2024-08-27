using Codebase.Services.QuestSystem;
using Codebase.Services.QuestSystem.Quests;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Codebase.Services.DiarySystem
{
    public sealed class DiaryQuest : Diary<Quest>
    {
        public static DiaryQuest Instance;
        public Quest observingQuest;
        private List<QuestData> _questDatas = new List<QuestData>();

        public override void Start()
        {
            base.Start();
            Instance = this;
            DontDestroyOnLoad(this);
            Quest.QuestGotEvent += Add;
            Quest.QuestPassedEvent += UpdateQuestData;
        }
        public override void Update()
        {
            base.Update();
        }
        private void OnDestroy()
        {
            Quest.QuestGotEvent -= Add;
            Quest.QuestPassedEvent -= UpdateQuestData;
        }

        public override void DeleteEmpty(ref List<Quest> objects)
        {
            foreach (Quest obj in objects)
            {
                if (obj.HasPassed)
                {
                    objects.Remove(obj);
                }
            }
        }
        public void DeleteEmpty()
        {
            foreach (Quest obj in _objectList.ToList())
            {
                if (obj.HasPassed)
                {
                    _objectList.Remove(obj);
                }
            }
        }
        public void DeleteAll()
        {
            foreach (Quest obj in _objectList.ToList())
            {
                _objectList.Remove(obj);
            }
        }

        public override void Add(Quest obj)
        {
            if (!_objectList.Contains(obj))
            {

                QuestData newQuest= new QuestData();
                newQuest.FilePath = obj.FilePath;
                newQuest.QuestName = obj.QuestName;
                _questDatas.Add(newQuest);

                base.Add(obj);
                Debug.Log($"{obj.QuestName} added on diary");
                observingQuest=obj;
            }
        }

        private void UpdateQuestData(Quest plug)
        {
            for (int i = 0; i < _objectList.Count; i++)
                _questDatas[i].HasPassed = _objectList[i].HasPassed;
        }
        public QuestData[] QuestDatas
        {
            get
            {
                return _questDatas.ToArray();
            }
            set
            {
                _questDatas = value.ToList();
            }
        }
    }
}
