using System;

namespace Codebase.Services.SceneLoader
{
	[Serializable]
	public struct SceneTransitionData
	{
		public string point;
		public string location;
	}

	public class SceneTransition
	{
		public SceneTransitionData data;
		//public SceneInstance scene;
	}
}
