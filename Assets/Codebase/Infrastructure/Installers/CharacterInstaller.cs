using UnityEngine;
using Zenject;
using Codebase.Components;

namespace Codebase.Infrastructure.Installers
{
	public class CharacterInstaller : MonoInstaller
	{
		[SerializeField]
		private CharacterComponent CharacterPrefab;
		[SerializeField]
		private CharacterPathComponent Path;

		public override void InstallBindings()
		{
			BindCharacterPath();
			BindCharacter();
		}

		private void BindCharacter()
		{
			var character = Container
				.InstantiatePrefabForComponent<CharacterComponent>(
					CharacterPrefab
				);

			Container
				.BindInstance(character)
				.AsSingle()
				.NonLazy();
		}

		private void BindCharacterPath()
		{
			Container
				.BindInstance(Path)
				.AsSingle()
				.NonLazy();
		}
	}
}