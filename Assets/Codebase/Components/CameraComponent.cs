using Cinemachine;
using Codebase.Services.SceneLoader;
using UnityEngine;
using Zenject;

namespace Codebase.Components
{
	public class CameraComponent : MonoBehaviour
	{
		[SerializeField]
		private CinemachineStateDrivenCamera _camera;

		private CharacterComponent _character;
		private SceneTransition _transitionData;

		[Inject]
		private void Construct(CharacterComponent character, SceneTransition transitionData)
		{
			_character = character;
			_transitionData = transitionData;
		}

		private void Start()
		{
			_camera.m_Follow = _character.transform;
			SetDolly(_transitionData.data.location);
		}

		public void SetDolly(string name)
		{
			_camera.m_AnimatedTarget.CrossFade(name, 0f);
		}

		public void SetDolly(string name, Transform follow)
		{
			_camera.m_Follow = follow;
			_camera.m_AnimatedTarget.CrossFade(name, 0f);
		}
	}
}