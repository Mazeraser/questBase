using DG.Tweening;
using UnityEngine;

namespace Codebase.Services.Animation
{
    public interface IAnimationService
    {
        void StartAnimation(RectTransform _rectTransform, float animationTime, float endPos, Ease easeMod);
    }
}