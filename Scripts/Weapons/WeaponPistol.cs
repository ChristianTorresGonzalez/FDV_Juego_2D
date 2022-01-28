using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : MonoBehaviour
{
    public ControladorDelegados controlador;

    public GameObject player;
    public GameObject weapon;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            controlador.SetPlayerWeapon(weapon.GetComponent<Weapon>());
        }
    }
}
