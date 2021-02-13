using UnityEngine;

public class ButtonCookiesAnimationComponent : MonoBehaviour
{
    Animator _animator;

    void Start() => _animator = GetComponent<Animator>();

    public void Click() => _animator.SetTrigger("Click");
}
