using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using UnityEngine;

namespace Codebase.UI 
{
	public class Fade : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup _group;
		[SerializeField]
		private float _fadeDuration = 2f;

		public float Duration => _fadeDuration;

		public void Out(Action onComplete)
		{
			_group.DOFade(0f, _fadeDuration).OnComplete(
				() => onComplete?.Invoke()
			);
		}

		public void In(Action onComplete)
		{
			_group.DOFade(1f, _fadeDuration).OnComplete(
				() => onComplete?.Invoke()
			);
		}
        public void Out()
        {
            _group.DOFade(0f, _fadeDuration);
        }

		public void In()
		{
			_group.DOFade(1f, _fadeDuration);
		}

        public void SetInteractable(bool value) => _group.interactable = value;
	}
}