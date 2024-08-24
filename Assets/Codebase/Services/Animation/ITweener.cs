using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace Codebase.Services.Animation
{
    public interface ITweener
    {
        TweenerCore<Vector2, Vector2, VectorOptions> TweenerAnchorPos(RectTransform target, float animationTime, float endPos, Ease easeMod = Ease.Unset);
    }
}