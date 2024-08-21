
using UnityEngine;
using Codebase.Services.Inventory;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
    }
}