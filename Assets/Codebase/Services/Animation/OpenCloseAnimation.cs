using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Codebase.Services.Animation
{
    public class OpenCloseAnimation : IOpenCloseAnimation
    {
        private ITweener _tweener;
        private bool _directionInventoryAnim;

        [Inject]
        private void Construct(ITweener tweener)
        {
            _tweener = tweener;
        }

        public void ChangeAnimationDirection(RectTransform rectTransform, float animationTime, float endPos, float startPose, Ease easeMod = Ease.Unset)
        {
            _directionInventoryAnim = !_directionInventoryAnim;

            if (_directionInventoryAnim)
                StartAnimation(rectTransform, animationTime, endPos, easeMod);
            else
                StartAnimation(rectTransform, animationTime, startPose, easeMod);
        }

        public void StartAnimation(RectTransform _rectTransform, float animationTime, float endPos, Ease easeMod)
        {
            _tweener.TweenerAnchorPos(_rectTransform, animationTime, endPos, easeMod);
        }

    }
}