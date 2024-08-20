using System;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Codebase.Installers
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