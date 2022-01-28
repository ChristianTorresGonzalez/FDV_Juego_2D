using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonLife : MonoBehaviour
{
    public ControladorDelegados controlador;
    private Animator animator;
    private int dragonLife;
    private bool dragonAlive;
    private int dragonLives;
    private bool dragonDizzy;

    void Start()
    {
        controlador = GameObject.FindWithTag("MainCamera").GetComponent<ControladorDelegados>();

        animator = GetComponent<Animator>();
        dragonLife = 100;
        dragonLives = 2;
        dragonAlive = true;
        dragonDizzy = false;
    }

    public void SetDragonHit(int damage)
    {
        dragonLife -= damage;

        CheckDragonAlive();
    }

    private void CheckDragonAlive()
    {
        if (dragonLife <= 0) {
            if (dragonLives == 1) {
                dragonAlive = false;
                
                animator.SetBool("dragonDie", true);
                
                Invoke("DestroyEnemy", 5);
            } else {
                dragonLife = 100;
                dragonDizzy = true;
                dragonLives--;
                
                animator.SetBool("dragonPatroling", false);
                animator.SetBool("dragonDizzy", true);
                GetComponent<BoxCollider2D>().isTrigger = true;

                Invoke("ResetDragon", 20);
            }
        }
    }

    public bool GetDragonAlive()
    {
        return dragonAlive;
    }

    public bool GetDragonDizzy()
    {
        return dragonDizzy;
    }

    private void DestroyEnemy()
    {
        controlador.SetPlayerPoints(130);
        GameObject.Destroy(this.gameObject);
    }

    private void ResetDragon()
    {
        animator.SetBool("dragonPatroling", true);
        animator.SetBool("dragonDizzy", false);
        GetComponent<BoxCollider2D>().isTrigger = false;
        dragonDizzy = false;
    }
}