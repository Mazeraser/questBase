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

        public override void Start()
        {
            base.Start();
            Instance = this;
            DontDestroyOnLoad(this);
            Quest.QuestGotEvent += Add;
        }
        public override void Update()
        {
            base.Update();

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

        public override void Add(Quest obj)
        {
            if (!_objectList.Contains(obj))
            {
                base.Add(obj);
                observingQuest=obj;
            }
        }
    }
}
