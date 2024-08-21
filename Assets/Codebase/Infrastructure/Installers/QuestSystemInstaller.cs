using Codebase.Services.Reward;
using UnityEngine;
using Zenject;

public class QuestSystemInstaller : MonoInstaller
{
    [SerializeField]
    private RewardSystem rewardSystem;

    public override void InstallBindings()
    {
        /*Container.BindInterfacesAndSelfTo<QuestScriptParser>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<QuestFactory>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<TriggerFactory>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();*/

        rewardSystem = Container.
            InstantiatePrefabForComponent<RewardSystem>(rewardSystem);
    }
}