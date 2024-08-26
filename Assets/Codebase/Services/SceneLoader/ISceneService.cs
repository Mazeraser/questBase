using System;
using System.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Codebase.Services.SceneService
{
	public interface ISceneService
	{
		AsyncOperationHandle<SceneInstance> Load(string sceneName, bool activateOnLoad, LoadSceneMode loadMode = LoadSceneMode.Additive, Action onLoaded = null);
		void Unload(Scene scene, Action onUnloaded = null);
		void Unload(string name, Action onUnloaded = null);
		void SetActiveScene(string name);
		void SetActiveScene(Scene scene);
		Scene GetActiveScene();
	}
}