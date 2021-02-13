using UnityEngine;

public class ButtonCookies : MonoBehaviour
{
    ButtonCookiesAnimationComponent _animationComponent;
    [SerializeField] GameController _gameController;
    [SerializeField] ScoreController _scoreController;

    void Start() => _animationComponent = GetComponent<ButtonCookiesAnimationComponent>();

    public void Click()
    {
        _animationComponent.Click();
        _gameController.Seconds++;
        _scoreController.TotalCookies++;
    }
}
