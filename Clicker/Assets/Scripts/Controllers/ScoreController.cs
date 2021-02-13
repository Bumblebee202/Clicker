using UnityEngine;

public class ScoreController : MonoBehaviour
{
    long _totalCookies;
    TextComponent _textComponent;

    public long TotalCookies
    {
        get => _totalCookies;
        set
        {
            _totalCookies = value;
            _textComponent.Display($"{_totalCookies} Cookies!");
        }
    }

    void Awake() => _textComponent = GetComponent<TextComponent>();
}
