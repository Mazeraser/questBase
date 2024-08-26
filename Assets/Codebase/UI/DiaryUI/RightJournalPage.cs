using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Codebase.Services.QuestSystem.Quests;
using Codebase.UI.DiaryUI;
using UnityEngine.UI;
using Codebase.Services.DiarySystem;

namespace Codebase.UI.DiaryUI
{
    public class RightJournalPage : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _name;
        [SerializeField]
        private TMP_Text _description;
        [SerializeField]
        private GameObject _observingQuestButton;

        private Quest _currentQuest;

        private void Start()
        {
            QuestPage.UpdateQuestInfo += SetRightPage;
            QuestPage.ClearQuestInfo += ClearPage;

            _observingQuestButton.GetComponent<Button>().onClick.AddListener(() => { SetObservingQuest(_currentQuest); });
        }
        private void Destroy()
        {
            QuestPage.UpdateQuestInfo -= SetRightPage;
            QuestPage.ClearQuestInfo -= ClearPage;
        }
        private void Update()
        {
            if (_currentQuest==null||_currentQuest.HasPassed)
                _observingQuestButton.SetActive(false);
            else
                _observingQuestButton.SetActive(true);
        }

        private void SetRightPage(Quest selectedQuest)
        {
            _name.text = selectedQuest.QuestName;
            _description.text = selectedQuest.QuestDescription;
            _currentQuest = selectedQuest;
            _observingQuestButton.SetActive(true);
        }
        private void ClearPage()
        {
            _name.text = "";
            _description.text = "";
            _currentQuest = null;
            _observingQuestButton.SetActive(false);
        }
        private void SetObservingQuest(Quest selectedQuest)
        {
            DiaryQuest.Instance.observingQuest = selectedQuest;
        }
    }
}