using System;
using UnityEngine;
using System.Globalization;
using Codebase.Services.QuestSystem.Quests;

namespace Codebase.Services.QuestSystem.Factories
{

    public class QuestFactory : MonoBehaviour
    {
        public static event Action<Transform, Quest> QuestCreatedEvent;

        public struct RawQuest
        {
            public string QuestName;
            public string QuestDescription;
            public string QuestType;
            public string QuestStarterName;
            public int StartItemID;
            public int ItemID;
            public string[] ExtraSettings;
        }

        private void Start()
        {
            DontDestroyOnLoad(this);

            QuestScriptParser.QuestInitializedEvent += CreateQuest;
        }
        private void OnDestroy()
        {
            QuestScriptParser.QuestInitializedEvent -= CreateQuest;
        }

        private void CreateQuest(RawQuest quest)
        {
            string type = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(quest.QuestType);
            if (IsQuestType(type))
            {
                GameObject vessel = new GameObject(quest.QuestName);
                Type t = Type.GetType("Codebase.Services.QuestSystem.Quests." + type + "Quest");
                vessel.AddComponent(Type.GetType("Codebase.Services.QuestSystem.Quests." + type + "Quest"));
                Quest quest_component = vessel.GetComponent<Quest>();
                quest_component.Copy(quest.QuestName, quest.QuestDescription, quest.QuestStarterName, quest.StartItemID, quest.ItemID, quest.ExtraSettings);
                QuestCreatedEvent?.Invoke(vessel.transform, quest_component);
            }
            else
                Debug.LogError($"{quest.QuestName} with type {quest.QuestType} doesn't exist.");
        }

        private bool IsQuestType(string type)
        {
            return (Type.GetType("Codebase.Services.QuestSystem.Quests." + type + "Quest"))!=null;
        }
    }
    
}