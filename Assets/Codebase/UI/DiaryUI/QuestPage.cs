using Codebase.Services.DiarySystem;
using Codebase.Services.QuestSystem.Quests;
using Codebase.UI.InfoUI;
using TMPro;
using UnityEngine;
using Zenject;

namespace Codebase.UI.DiaryUI
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class QuestPage : Page<Quest>
    {
        private DiaryQuest _diary;
        private Fade _fade;

        private bool _isFirstSliding = true;
        private Quest _selectedQuest=null;
        private int _phraseIndex=0;
        private bool _isActive=false;

        [SerializeField]
        private TMP_Text _name;
        [SerializeField]
        private TMP_Text _description;

        [Inject]
        private void Construct(DiaryQuest diary, Fade fade)
        {
            _diary = diary;
            _fade = fade;
        }

        public override void Start()
        {
            Quest.QuestGotEvent += AddObjectToPage;

            _name.text = "";
            _description.text = "";
        }
        private void OnDestroy()
        {
            Quest.QuestGotEvent -= AddObjectToPage;
        }
        private void Update()
        {
            SlidingQuests();
        }

        public override void VisualizeDiary()
        {
            if (!_visualised)
            {
                Debug.Log("Visualizing quests...");
                foreach (Quest quest in _diary.Get())
                    AddObjectToPage(quest);
                _visualised = true;
            }
        }

        public override void AddObjectToPage(Quest obj)
        {
            GameObject clone = Instantiate(_objectPrefab);
            clone.transform.SetParent(this.transform);
            clone.GetComponent<IInfoUI<Quest>>().SetInfoObject(obj);
        }

        public override void ShowPage()
        {
            _isFirstSliding = true;
            _isActive=true;
        }
        public override void HidePage()
        {
            _isActive = false;

            _name.text = "";
            _description.text = "";
        }

        public void SlidingQuests()
        {
            if (_input.SlideAnswersPressed&&_isActive)
            {
                if (_isFirstSliding)
                {
                    _phraseIndex = 0;

                    _isFirstSliding = false;
                }
                else
                {
                    _phraseIndex += _input.SlideAnswers;

                    if (_phraseIndex < 0)
                    {
                        _phraseIndex = _diary.Get().Length - 1;
                    }
                    else if (_phraseIndex == _diary.Get().Length)
                    {
                        _phraseIndex = 0;
                    }

                }
                _selectedQuest = _diary.Get()[_phraseIndex];
                SetRightPage(_selectedQuest);
            }

           
        } 
        private void SetRightPage(Quest selectedQuest)
        {
            _name.text = selectedQuest.QuestName;
            _description.text = selectedQuest.QuestDescription;
        }
    }
}