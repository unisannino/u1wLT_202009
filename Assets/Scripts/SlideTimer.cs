using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEditor;
using UnityEngine.U2D;

public class SlideTimer : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _snowman;
    [SerializeField]
    float _timeLimit;
    [SerializeField]
    PixelPerfectCamera _camera;

    [SerializeField]
    float _endPosX;

    private void Start()
    {
        _endPosX = _camera.refResolutionX * 0.125f * 0.5f - 1;
        var rotate = _snowman.transform.DORotate(new Vector3(0, 0, -360), _timeLimit * 0.75f * 0.01f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        _snowman.transform.DOMoveX(_endPosX, _timeLimit).SetEase(Ease.Linear).OnComplete(() =>
        {
            rotate.Kill();
        });
    }

    private void OnDrawGizmos()
    {
        //_endPosX = Camera.main.ViewportToWorldPoint(Vector3.right).x - 1;
        _endPosX = _camera.refResolutionX * 0.125f * 0.5f -1;
        var posY = _snowman.transform.position.y;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(_endPosX - 1, posY + 0.5f, 0), new Vector3(_endPosX + 1, posY + 0.5f, 0));
        Gizmos.DrawLine(new Vector3(_endPosX - 1, posY - 1.5f, 0), new Vector3(_endPosX + 1, posY - 1.5f, 0));
        Gizmos.DrawLine(new Vector3(_endPosX - 1, posY + 0.5f, 0), new Vector3(_endPosX - 1, posY - 1.5f, 0));
        Gizmos.DrawLine(new Vector3(_endPosX + 1, posY + 0.5f, 0), new Vector3(_endPosX + 1, posY - 1.5f, 0));
    }
}
