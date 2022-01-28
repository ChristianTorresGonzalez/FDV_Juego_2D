using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickRevive : MonoBehaviour
{
    public GameObject player;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            animator.SetBool("usingMachine", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            animator.SetBool("usingMachine", false);
        }
    }
}
