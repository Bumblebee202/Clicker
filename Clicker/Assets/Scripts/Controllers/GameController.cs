using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    DateTime _dateTime;
    TextComponent _promptTextComponent;
    [SerializeField] int _seconds = 10;
    [SerializeField] ScoreController _scoreController;
    [SerializeField] Timer _timer;

    public int Seconds
    {
        get => _seconds;
        set
        {
            _seconds = value;
            _timer.Interval = new TimeSpan(0, 0, _seconds);
            _promptTextComponent.Display($"1 cookies per {_seconds} second");
        }
    }

    void Awake()
    {
        _promptTextComponent = GetComponent<TextComponent>();

        LoadData();

        _timer.Tick += TimerTick;
    }

    void Start() => _timer.Begin();

    void TimerTick() => _scoreController.TotalCookies++;

    void LoadData()
    {
        DateTime currentDate = DateTime.UtcNow;

        _dateTime = DateTime.Parse(PlayerPrefs.GetString("DateTime", currentDate.ToString()));
        long totalCookies = long.Parse(PlayerPrefs.GetString("TotalCookies"), 0);

        TimeSpan difference = currentDate.Subtract(_dateTime);

        Seconds = PlayerPrefs.GetInt("Seconds", _seconds);

        double cookies = difference.TotalSeconds / _seconds;
        _scoreController.TotalCookies = totalCookies + (long)cookies;
    }

    void SaveData()
    {
        _dateTime = DateTime.UtcNow;
        PlayerPrefs.SetString("DateTime", _dateTime.ToString());
        PlayerPrefs.SetString("TotalCookies", _scoreController.TotalCookies.ToString());
        PlayerPrefs.SetInt("Seconds", _seconds);
    }

    void OnApplicationFocus(bool focus) => LoadData();

    void OnApplicationPause(bool pause) => SaveData();

    void OnApplicationQuit() => SaveData();


}
