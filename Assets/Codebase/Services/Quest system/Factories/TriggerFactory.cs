using Codebase.Services.QuestSystem.QuestTriggers;
using Codebase.Services.QuestSystem.Quests;
using System;
using UnityEngine;
using System.Globalization;

namespace Codebase.Services.QuestSystem.Factories
{
    public class TriggerFactory : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);
            QuestFactory.QuestCreatedEvent += CreateTrigger;
        }

        private void CreateTrigger(Transform quest_transform, Quest quest)
        {
            GameObject trigger = new GameObject(quest.QuestName+"_trigger");
            trigger.transform.SetParent(quest_transform);
            quest.SetTypeToTrigger(trigger); //add class in dependency of quest type
        }
    }
}