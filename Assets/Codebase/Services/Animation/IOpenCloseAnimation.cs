using DG.Tweening;
using UnityEngine;

namespace Codebase.Services.Animation
{
    public interface IOpenCloseAnimation : IAnimationService
    {
        void ChangeAnimationDirection(RectTransform rectTransform, float animationTime, float endPos, float startPose, Ease easeMod = Ease.Unset);
    }
}