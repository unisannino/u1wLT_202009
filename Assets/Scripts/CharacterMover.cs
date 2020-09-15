using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    [SerializeField]
    float _octDuration;
    [SerializeField]
    float _beeMoveDuration;
    [SerializeField]
    float _beeRotateDuration;
    [SerializeField]
    RectTransform _octRectTrans;
    [SerializeField]
    RectTransform _beeRectTrans;

    Canvas _root;

    // Start is called before the first frame update
    void Start()
    {
        _root = GetComponent<Canvas>();
        // MoveOct();
        //MoveBee();
    }

    public void MoveOct()
    {
        var seq = DOTween.Sequence();
        seq.Append(_octRectTrans.DOAnchorPosX(-_octRectTrans.anchoredPosition.x + _root.pixelRect.width, _octDuration).SetEase(Ease.Linear));
        seq.Join(_octRectTrans.DOAnchorPosY(50, 0.5f).SetLoops(-1, LoopType.Yoyo));
        
    }

    public void MoveBee()
    {
        var seq = DOTween.Sequence();
        var posX = _beeRectTrans.anchoredPosition.x;

        seq.Append(_beeRectTrans.DOAnchorPosX(-_root.pixelRect.width * 0.5f, _beeMoveDuration).SetEase(Ease.Linear));
        seq.Append(_beeRectTrans.DORotate(Vector3.forward * -360, _beeRotateDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        seq.Append(_beeRectTrans.DOAnchorPosX(-posX - _root.pixelRect.width, _beeMoveDuration).SetEase(Ease.Linear));
        //seq.SetEase(Ease.Linear);
    }
}
