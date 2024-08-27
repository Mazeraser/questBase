
using UnityEngine;
using Codebase.Services.InventorySystem;
using Zenject;
using Codebase.Services.SaveSystem;

public class InventoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Inventory>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InventorySave>().AsSingle().NonLazy();
    }
}