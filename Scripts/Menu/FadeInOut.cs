using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetFadeIn()
    {
        animator.SetBool("fadeIn", true);
    }

    public void SetFadeOut()
    {
        animator.SetBool("fadeOut", true);
        this.gameObject.SetActive(false);
    }
}
