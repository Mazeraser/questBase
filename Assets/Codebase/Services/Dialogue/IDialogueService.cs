using Fungus;
using UnityEngine.UI;

namespace Codebase.Services.Dialogue
{
    public interface IDialogueService
    {
        void StartDialogue(Flowchart flowchart, string messageName, Button activeMenuButton, DialogInput dialogInput, MenuDialog menuDialog);

        void PhraseSliding();

        void SlidingAnswers();

        void EnterTheAnswer();

        void EndDialogue();
    }
}