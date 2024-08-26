using System;
using UnityEngine;

namespace Codebase.Services.QuestSystem.QuestTriggers
{
    public class InfoQuestTrigger : MonoBehaviour
    {
        [SerializeField]
        private string _questPath; //all json's stored in QuestJson folder

        public static event Action<string> QuestThrowedEvent;

        private void Start()
        {
            if(_questPath != "")
                QuestThrowedEvent?.Invoke(_questPath);
            Destroy(gameObject);
        }
    }
}