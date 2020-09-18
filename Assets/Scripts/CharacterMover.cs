using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    [SerializeField]
    float _octMoveYDuration;

    Canvas _root;

    Vector2 _octStartAnchorPos;
    Sequence _octSeq;
    Vector2 _beeStartAnchorPos;
    Sequence _beeSeq;

    // Start is called before the first frame update
    void Awake()
    {
        _root = GetComponent<Canvas>();

        _octStartAnchorPos = _octRectTrans.anchoredPosition;
        _beeStartAnchorPos = _beeRectTrans.anchoredPosition;
    }

    public void ResetCharactors()
    {
        if (_octSeq != null && _octSeq.active)
        {
            _octSeq.Kill();
        }
        if (_beeSeq != null && _beeSeq.active)
        {
            _beeSeq.Kill();
        }
        _octRectTrans.anchoredPosition = _octStartAnchorPos;
        _beeRectTrans.anchoredPosition = _beeStartAnchorPos;
    }

    public void MoveOct()
    {
        if (_octSeq != null && _octSeq.active)
        {
            _octSeq.Kill();
        }
        _octRectTrans.anchoredPosition = _octStartAnchorPos;

        _octSeq = DOTween.Sequence();
        _octSeq.Append(_octRectTrans.DOAnchorPosX(-_octRectTrans.anchoredPosition.x + _root.pixelRect.width, _octDuration).SetEase(Ease.Linear));
        _octSeq.Join(_octRectTrans.DOAnchorPosY(-_octStartAnchorPos.y, _octDuration).SetEase(Ease.InOutFlash, 8));
        
    }

    public void MoveBee()
    {
        if (_beeSeq != null && _beeSeq.active)
        {
            _beeSeq.Kill();
        }
        _beeRectTrans.anchoredPosition = _beeStartAnchorPos;

        _beeSeq = DOTween.Sequence();
        var posX = _beeRectTrans.anchoredPosition.x;

        _beeSeq.Append(_beeRectTrans.DOAnchorPosX(posX -_root.pixelRect.width * 0.5f, _beeMoveDuration).SetEase(Ease.Linear));
        _beeSeq.Append(_beeRectTrans.DORotate(Vector3.forward * -360, _beeRotateDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        _beeSeq.Append(_beeRectTrans.DOAnchorPosX(-posX - _root.pixelRect.width, _beeMoveDuration).SetEase(Ease.Linear));
    }
}
