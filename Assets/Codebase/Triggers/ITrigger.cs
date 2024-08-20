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
}