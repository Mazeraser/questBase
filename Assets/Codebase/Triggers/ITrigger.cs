using UnityEngine;

namespace Codebase.Triggers
{
    public interface ITrigger
    {
        Collider2D Collider { get; set; }
        void PlayerEntered(bool isPlayerInTrigger);
        void Interact();
    }

    public interface ITriggerSceneTransition : ITrigger
    {

    }

    public interface ITriggerItemCreation : ITrigger
    {

    }
    public interface ITriggerDialogueInteraction : ITrigger
    {
        void StartDialogue(string messageToExecuteDialogue);
        void DialogueFinished();
    }
}