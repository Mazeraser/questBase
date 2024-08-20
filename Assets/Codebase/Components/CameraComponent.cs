using Cinemachine;
using Codebase.Services.SceneLoader;
using UnityEngine;
using Zenject;

public class CameraComponent : MonoBehaviour
{
	[SerializeField]
	private CinemachineStateDrivenCamera _camera;

	private CharacterComponent _character;
	private SceneTransitionData _transitionData;

	[Inject]
	private void Construct(CharacterComponent character, SceneTransitionData transitionData)
	{
		_character = character;
		_transitionData = transitionData;
	}

	private void Start()
	{
		_camera.m_Follow = _character.transform;
		SetDolly(_transitionData.location);
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
