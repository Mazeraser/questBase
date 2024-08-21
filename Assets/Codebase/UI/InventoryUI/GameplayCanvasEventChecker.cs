﻿using Codebase.Services.Input;
using Codebase.Triggers;
using Codebase.UI.InventoryUI;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Codebase.UI
{
    public class GameplayCanvasEventChecker : MonoBehaviour
    {
        private const int UseIconStartPos = -45;
        private const int UseIconEndPos = 0;

        private const int InventoryStartPos = -215;
        private const int InventoryEndPos = 90;

        public RectTransform InventoryMenu;

        public float AnimationTime;

        [SerializeField]
        private InventoryViewModel _inventoryItemContainer;

        private InputService _input;

        private ITriggerItemCreation _triggerItemCreation;

        private bool slide;

        [Inject]
        private void Construct(InputService input)
        {
            _input = input;
        }

        private void Start()
        {
            _input.DeactivateUI();
            _input.ActivateGameplay();

            _inventoryItemContainer.GetVariables(this);

            _inventoryItemContainer.ShowInventoryDelegate = OpenInventoryAnimation;
        }

        private void Update()
        {
            InventoryInteraction();
        }

        public void GetTrigger(GameObject trigger)
        {
            if (trigger.TryGetComponent(out ITriggerItemCreation triggerItemCreation))
            {
                _triggerItemCreation = triggerItemCreation;
            }
            else
            {
                _triggerItemCreation = null;
            }   
        }

        private void InventoryInteraction()
        {
            if (_input.OpenInventoryPressed)
            {
                OpenInventoryAnimation();
            }
            
            if (_input.CloseInventoryPressed)
            {
                CloseInventoryAnimation();
            }

            /*
             * if (_input.ChooseItemPressed && _triggerItemInteraction != null)
            {
                _inventoryItemContainer.UseItem(_triggerItemInteraction);
            }

            if (_input.ItemSlider<0&&slide)
            {
                _inventoryItemContainer.ChangeActiveItem(-1);
                slide = false;
            }
            else if (_input.ItemSlider>0&&slide)
            {
                _inventoryItemContainer.ChangeActiveItem(1);
                slide = false;
            }
            else if(_input.ItemSlider==0)
            {
                slide = true;
            }*/
        }

        private void OpenInventoryAnimation()
        {
            InventoryMenu.DOAnchorPosY(InventoryEndPos, AnimationTime);
            Debug.Log("Open inventory");
            
            _input.Store();
            _input.DeactivateGameplay();
            _input.ActivateUI();

            _inventoryItemContainer.ResetActiveItem();
        }
        
        public void CloseInventoryAnimation()
        {
            InventoryMenu.DOAnchorPosY(InventoryStartPos, AnimationTime);
            Debug.Log("Close inventory");
            _input.Restore();

            _inventoryItemContainer.ResetActiveItem();
        }
    }
}