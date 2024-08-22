using Codebase.Services.QuestSystem.Quests;
using Codebase.Libraries.Stats;
using System.Collections.Generic;
using System.Linq;
using Fungus;
using UnityEngine;
using System;

namespace Codebase.Services.QuestSystem.QuestTriggers
{
    public class ScriptQuestTrigger : QuestTrigger
    {
        private ScriptQuest _quest;

        public override void Start()
        {
            base.Start();
            _quest = transform.GetComponentInParent<ScriptQuest>();
        }
        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void Interact(GameObject area)
        {
            if(area.name ==_quest.AreaName)
            {
                PassQuest();
            }
        }
    }
}