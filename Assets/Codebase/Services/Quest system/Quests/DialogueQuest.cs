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

        public DialogueQuest(string name, string description, string questStarterName, int startItemID, int ItemID, string[] settings) : base(name,description,questStarterName, startItemID, ItemID)
        {
            _endMessageName = settings[0];
        }
        public override void Copy(string name, string description, string questStarterName, int startItemID, int ItemID, string[] settings) 
        {
            base.Copy(name, description, questStarterName, startItemID, ItemID,settings);
            _endMessageName = settings[0];
        }
        public override void SetTypeToTrigger(GameObject trigger)
        {
            trigger.AddComponent<DialogueQuestTrigger>();
        }
    }
}