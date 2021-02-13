using UnityEngine;
using UnityEngine.UI;

public class TextComponent : MonoBehaviour
{
    [SerializeField] Text _text;

    public string Text
    {
        get => _text.text;
        set => _text.text = value;
    }

    public void Display(string text) => _text.text = text;
}
