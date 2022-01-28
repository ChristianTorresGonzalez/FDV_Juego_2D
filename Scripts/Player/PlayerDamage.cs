using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public ControladorDelegados controlador;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<DragonLife>().GetDragonAlive()) {
                controlador.SetPlayerHit();
            }
        }
    }
}
