using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SlideManager : MonoBehaviour
{
    [SerializeField]
    Slide[] _slides;
    [SerializeField]
    int _currentSlideId;

    Slide CurrentSlide => _slides[_currentSlideId];

    // Start is called before the first frame update
    void Start()
    {
        _slides = GetComponentsInChildren<Slide>();

        CurrentSlide.ResetSlide();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPressedButtonNext())
        {
            if (CurrentSlide.IsComplete && _currentSlideId < _slides.Length)
            {
                CurrentSlide.FinishSlide();
                _currentSlideId++;
                CurrentSlide.ResetSlide();
            }
            else
            {
                CurrentSlide.ExecuteNextEvent();
            }
        }
        else if (IsPressedButtonBack() && _currentSlideId > 0)
        {
            CurrentSlide.FinishSlide();
            _currentSlideId--;
            CurrentSlide.ResetSlide();
        }
    }

    bool IsPressedButtonNext()
    {
        return Input.GetMouseButtonDown((byte)MouseButton.LeftMouse) && !IsPressedButtonBack();
    }
    bool IsPressedButtonBack()
    {
        return Input.GetMouseButtonDown((byte)MouseButton.RightMouse) && !IsPressedButtonNext();
    }
}
