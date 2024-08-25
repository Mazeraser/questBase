using Codebase.Services.DiarySystem;
using TMPro;
using UnityEngine;

namespace Codebase.UI.DiaryUI
{
    public class MainQuestField : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text field;

        private void Update()
        {
            if(DiaryQuest.Instance.observingQuest == null)
            {
                GetComponent<CanvasGroup>().alpha = 0f;
                field.text = "";
            }
            else
            {
                GetComponent<CanvasGroup>().alpha = 1f;
                field.text = DiaryQuest.Instance.observingQuest.QuestName;
            }
        }
    }
}