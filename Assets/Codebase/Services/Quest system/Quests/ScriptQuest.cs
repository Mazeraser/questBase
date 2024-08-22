using UnityEngine;
using Codebase.Services.QuestSystem.QuestTriggers;
using System;

namespace Codebase.Services.QuestSystem.Quests
{
    public class ScriptQuest : Quest
    {
        private string _areaName;
        public string AreaName
        {
            get => _areaName;
        }
        private string _nextStageQuestName;
        public string NextStageQuestName
        {
            get => _nextStageQuestName;
        }

        public static event Action<string> GotNextStageQuest;

        public ScriptQuest(string name, string description, string questStarterName, int startItemID, int ItemID, string[] settings) : base(name, description, questStarterName, startItemID, ItemID)
        {
            _areaName = settings[0];
        }
        public override void Copy(string name, string description, string questStarterName, int startItemID, int ItemID, string[] settings)
        {
            base.Copy(name, description, questStarterName, startItemID, ItemID, settings);
            _areaName = settings[0];
            _nextStageQuestName = settings[1];
        }
        public override void SetTypeToTrigger(GameObject trigger)
        {
            trigger.AddComponent<ScriptQuestTrigger>();
        }
    }
}