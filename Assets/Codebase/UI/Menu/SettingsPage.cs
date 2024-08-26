using UnityEngine;
using UnityEngine.UI;

namespace Codebase.UI.Menu
{
	public class SettingsPage : Page
	{
		[SerializeField]
		private Button _controls;
		[SerializeField]
		private Button _authors;
		[SerializeField]
		private Button _back;

		private readonly int _trigger = Animator.StringToHash("ToSettings");

		private void Start()
		{
			_back.onClick.AddListener(() =>
			{
				_story.Pop();
			});
		}

		public override void Open()
		{
			base.Open();
			InvokeTrigger(_trigger);
		}

		public override void Close()
		{
			base.Close();
		}
	}
}