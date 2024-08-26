using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Codebase.Services.Animation
{
    public class Tweener : ITweener
    {
        public TweenerCore<Vector2, Vector2, VectorOptions> TweenerAnchorPos(RectTransform target, float animationTime, float endPos, Ease easeMod = Ease.Unset)
        {
            return target.DOAnchorPos(new Vector2(0, endPos), animationTime, false)
                .SetEase(easeMod);
        }
    }
}