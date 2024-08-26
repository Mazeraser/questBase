using Codebase.Infrastructure;
using Codebase.Infrastructure.States;
using Codebase.Services.SceneLoader;
using Codebase.UI;
using UnityEngine;
using UnityEngine.Video;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Zenject;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private SceneTransitionData _sceneTransitionData;

    private GameStateMachine _state;
    private Fade _fade;
    private SceneTransition _transition;

    [Inject]
    private void Construct(GameStateMachine state, Fade fade, SceneTransition transition)
    {
        _state = state;
        _fade = fade;
        _transition = transition;
    }

    private void Start()
    {
        _transition.data = _sceneTransitionData;
        _fade.In(() =>
        {
            _state.Enter<LoadLevelState>();
        });
    }
}
