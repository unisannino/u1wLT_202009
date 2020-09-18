using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Slide : MonoBehaviour
{
    [SerializeField]
    UnityEvent _resetEvent;
    [SerializeField]
    UnityEvent _finishEvent;
    [SerializeField]
    UnityEvent[] _events;
    [SerializeField]
    byte _currentEventId;

    Canvas _canvas;
    internal bool IsComplete => _currentEventId >= _events.Length;

    // Start is called before the first frame update
    void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    internal void ResetSlide()
    {
        _canvas.enabled = true;
        _currentEventId = 0;
        _resetEvent.Invoke();
    }

    internal void ExecuteNextEvent()
    {
        _events[_currentEventId].Invoke();
        _currentEventId++;
    }

    internal void FinishSlide()
    {
        _canvas.enabled = false;
        _finishEvent.Invoke();
    }
}
