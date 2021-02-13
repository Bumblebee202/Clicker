using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    Coroutine _coroutine;

    public TimeSpan Interval { get; set; }

    public event Action Tick;

    public void Begin() => _coroutine = StartCoroutine(Iteration());

    IEnumerator Iteration()
    {
        while (true)
        {
            Tick?.Invoke();
            yield return new WaitForSecondsRealtime((float)Interval.TotalSeconds);
        }
    }

    public void End() => StopCoroutine(_coroutine);
}