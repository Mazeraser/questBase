using Codebase.Services.Inventory;
using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

namespace Codebase.Triggers
{
    public class TriggerInteractionGetItem : MonoBehaviour, ITriggerItemCreation
    {
        public static event Action<int,bool> ItemGotEvent;
        public static event Action InventoryIsFullEvent;

        private Inventory _inventory;

        [SerializeField]
        private SpriteRenderer _interactionIcon;

        [SerializeField]
        private int _itemID;

        /*[SerializeField]
        private string _fungusFlag;
        [SerializeField]
        private Flowchart _flowchart;*/


        public Collider2D Collider { get; set; }

        [SerializeField]
        private bool _showInventory;

        [Inject]
        private void Contruct(Inventory inventory)
        {
            _inventory = inventory;
        }

		private void Start()
        {
            Collider = GetComponent<Collider2D>();

			_interactionIcon.DOFade(0f, 0f);
		}

        public void PlayerEntered(bool isPlayerInTrigger)
        {
			if (isPlayerInTrigger)
			{
				_interactionIcon.DOFade(1f, 0.3f);
			}
			else
			{
				_interactionIcon.DOFade(0f, 0.3f);
			}
		}

        public void Interact()
        {
            if (_inventory.IsFull)
                InventoryIsFullEvent?.Invoke();
            else
            {
                ItemGotEvent?.Invoke(_itemID, _showInventory);
                /*if(_fungusFlag!="")
                    _flowchart.SetBooleanVariable(_fungusFlag, true);*/
                Destroy(this.gameObject);
            }
                
        }
    }
}