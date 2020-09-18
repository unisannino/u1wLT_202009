using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlipPenguin : MonoBehaviour
{
    [SerializeField]
    RectTransform _penguin;
    [SerializeField]
    float _moveDistance;
    [SerializeField]
    float _moveDuration;
    [SerializeField]
    Sprite _penguinFoolishFace;
    [SerializeField]
    float _penguinSlipDuration;
    [SerializeField]
    float _penguinFallDuration;
    [SerializeField]
    float _penguinFallDistance;
    [SerializeField]
    float _interval;

    Vector2 _penguinStartAnchorPos;
    Image _penguinImage;
    Sprite _penguinNormalFace;

    Tween _penguinFloat;
    Sequence _penguinSlipSeq;

    void Awake()
    {
        _penguinStartAnchorPos = _penguin.anchoredPosition;
        _penguinImage = _penguin.GetComponent<Image>();
        _penguinNormalFace = _penguinImage.sprite;
    }

    public void FloatPenguin()
    {
        if (_penguinFloat != null && _penguinFloat.active)
        {
            _penguinFloat.Kill();
        }

        _penguinImage.sprite = _penguinNormalFace;
        _penguin.anchoredPosition = _penguinStartAnchorPos;
        _penguinFloat = _penguin.DOAnchorPosY(_penguinStartAnchorPos.y + _moveDistance, _moveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    public void SlipAndFallPenguin()
    {
        if (_penguinFloat != null && _penguinFloat.active)
        {
            _penguinFloat.Kill();
        }
        if (_penguinSlipSeq != null && _penguinSlipSeq.active)
        {
            _penguinSlipSeq.Kill();
        }

        _penguinImage.sprite = _penguinFoolishFace;
        _penguinSlipSeq = DOTween.Sequence();
        _penguinSlipSeq.Append(_penguin.DORotate(new Vector3(0, 180, 45), _penguinSlipDuration).SetEase(Ease.InExpo));
        _penguinSlipSeq.AppendInterval(_interval);
        _penguinSlipSeq.Append(_penguin.DOAnchorPosY(_penguin.anchoredPosition.y - _penguinFallDistance, _penguinFallDuration).SetEase(Ease.InExpo));
    }
}
