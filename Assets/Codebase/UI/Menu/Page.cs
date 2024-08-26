using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Codebase.UI.Menu
{
	public class Page : MonoBehaviour, IPage
	{
		[SerializeField]
		protected PageStory _story;
		[SerializeField]
		protected CanvasGroup _group;
		[SerializeField]
		protected Animator _animator;

		public virtual async void Open()
		{
			gameObject.SetActive(true);
			await _group.DOFade(1f, 0.6f).AsyncWaitForCompletion().AsUniTask();
			_group.blocksRaycasts = true;
			_group.interactable = true;
		}

		public virtual async void Close()
		{
			gameObject.SetActive(false);
			await _group.DOFade(0f, 0.6f).AsyncWaitForCompletion().AsUniTask();
			_group.blocksRaycasts = false;
			_group.interactable = false;
		}

		public virtual void InvokeTrigger(int trigger)
		{
			_animator.SetTrigger(trigger);
		}
	}
}