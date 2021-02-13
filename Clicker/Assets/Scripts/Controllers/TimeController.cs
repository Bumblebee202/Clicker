using System;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    Timer _timer;
    TextComponent _textComponent;

    void Awake()
    {
        _timer = GetComponent<Timer>();
        _textComponent = GetComponent<TextComponent>();

        _timer.Interval = new TimeSpan(0, 0, 1);
        _timer.Tick += Tick;
    }

    void Start() => _timer.Begin();

    void Tick() => _textComponent.Display($"Time: {DateTime.UtcNow.ToLongTimeString()}");
}
