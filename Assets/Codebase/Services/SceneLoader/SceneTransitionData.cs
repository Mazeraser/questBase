using System;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Codebase.Services.SceneLoader
{
	[Serializable]
	public struct SceneTransitionData
    {
        public string sceneName;
        public string point;
		public string location;
	}

	public class SceneTransition
	{
		public SceneTransitionData data;
		public SceneInstance scene;
	}
}
