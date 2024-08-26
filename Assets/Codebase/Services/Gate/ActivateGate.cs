using Codebase.Services.QuestSystem.Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Services.Gate
{
    public class ActivateGate : QuestGate
    {
        [SerializeField]
        private GameObject _prefab;

        private void Start()
        {
            Quest.QuestPassedEvent += CatchQuest;
            _prefab.SetActive(false);
        }
        private void OnDestroy()
        {
            Quest.QuestPassedEvent -= CatchQuest;
        }

        protected override void OpenGate()
        {
            _prefab.SetActive(true);
        }
    }
}
