using Codebase.Services.QuestSystem.QuestTriggers;
using UnityEngine;

namespace Codebase.Services.QuestSystem.Quests
{
    public class DialogueQuest : Quest
    {
        private string _endMessageName;
        public string EndMessageName
        {
            get => _endMessageName;
        }

        public DialogueQuest(string filePath, string name, string description, string questStarterName, int startItemID, int ItemID, string nextQuestName, string[] settings) : base(filePath, name, description,questStarterName, startItemID, ItemID, nextQuestName)
        {
            _endMessageName = settings[0];
        }
        public override void Copy(string filePath, string name, string description, string questStarterName, int startItemID, int ItemID, string nextQuestName, string[] settings) 
        {
            base.Copy(filePath, name, description, questStarterName, startItemID, ItemID, nextQuestName, settings);
            _endMessageName = settings[0];
        }
        public override void SetTypeToTrigger(GameObject trigger)
        {
            trigger.AddComponent<DialogueQuestTrigger>();
        }
    }
}