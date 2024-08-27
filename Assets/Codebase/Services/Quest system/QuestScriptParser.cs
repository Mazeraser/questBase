using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Codebase.Services.QuestSystem.QuestTriggers;
using Codebase.Services.QuestSystem.Factories;
using Codebase.Services.QuestSystem.Quests;
using System.Runtime.Serialization;

namespace Codebase.Services.QuestSystem
{
    public class QuestScriptParser : MonoBehaviour
    {
        public static event Action<QuestFactory.RawQuest> QuestInitializedEvent;

        private void Awake()
        {
            InfoQuestTrigger.QuestThrowedEvent += DeserializeData;
        }
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
        private void OnDestroy()
        {
            InfoQuestTrigger.QuestThrowedEvent -= DeserializeData;
        }

        public static void DeserializeData(string path)
        {
            var jsonTextFile = Resources.Load<TextAsset>(path);
            var quest = JsonConvert.DeserializeObject<QuestFactory.RawQuest>(jsonTextFile.text);
            quest.FilePath = path;
            QuestInitializedEvent?.Invoke(quest);
        }
    }
}