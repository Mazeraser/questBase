using UnityEngine;
using Zenject;
using Codebase.Components;

namespace Codebase.Infrastructure.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField]
        private CameraComponent _camera;

        public override void InstallBindings()
        {
            Container
                .BindInstance(_camera)
                .AsSingle()
                .NonLazy();
        }
    }
}