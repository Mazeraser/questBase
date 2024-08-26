using Codebase.Services.QuestSystem.QuestTriggers;
using UnityEngine;

namespace Codebase.Services.QuestSystem.Quests
{
    public class CollectQuest : Quest
    {
        private int _itemCount;
        public int ItemCount
        {
            get => _itemCount;
        }
        private int[] _itemID;
        public int[] ItemID
        {
            get => _itemID;
        }
        private string _objectDialogueName;
        public string ObjectDialogueName
        {
            get => _objectDialogueName;
        }

        public CollectQuest(string name, string description, string questStarterName, int startItemID, int ItemID, string nextQuestName, string[] settings) : base(name, description, questStarterName, startItemID, ItemID, nextQuestName)
        {
            _itemCount = int.Parse(settings[0]);

            _itemID = new int[_itemCount];
            for(int i = 1; i < _itemCount; i++)
            {
                _itemID[i] = int.Parse(settings[i]);
            }

            _objectDialogueName = settings[_itemCount+1];
        }
        public override void Copy(string name, string description, string questStarterName, int startItemID, int ItemID, string nextQuestName, string[] settings)
        {
            base.Copy(name, description, questStarterName, startItemID, ItemID, nextQuestName, settings);

            _itemCount = int.Parse(settings[0]);

            _itemID= new int[_itemCount];
            for(int i = 1; i <= _itemCount; i++)
            {
                _itemID[i-1] = int.Parse(settings[i]);
            }

            _objectDialogueName = settings[_itemCount+1];
        }

        public override void SetTypeToTrigger(GameObject trigger)
        {
            trigger.AddComponent<CollectQuestTrigger>();
        }

    }
}