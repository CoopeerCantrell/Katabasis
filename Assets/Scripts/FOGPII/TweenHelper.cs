using UnityEngine;
using DG.Tweening;

public static class TweenHelper
{
    public static Sequence PunchUp(Transform transform)
    {
        Sequence sq = DOTween.Sequence();

        sq.Append(transform.DOLocalMoveY(1.0f, 1.0f));

        sq.Join(transform.DOPunchScale(new Vector3(1.5f, 1.5f, 1.5f), 0.7f));
        return sq;
    }
}
