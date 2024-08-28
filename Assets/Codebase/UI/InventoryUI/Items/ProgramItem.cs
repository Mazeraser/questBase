using UnityEngine;

namespace Codebase.UI.InventoryUI.Items
{
    public class ProgramItem : Item
    {
        [SerializeField]
        private GameObject _programObject;
        public GameObject GetProgrammObject()
        {
            return _programObject;
        }

        public override void InitItemFromDictionary(int id)
        {
            base.InitItemFromDictionary(id);
            foreach (ProgramItem item in ItemLibrary.ProgramItems)
            {
                if (item.GetID() == id)
                {
                    _programObject = item.GetProgrammObject();
                }
            }
        }
        public override void Use()
        {
            Debug.Log("Programm item is used");
            Instantiate(_programObject);
        }
    }
}