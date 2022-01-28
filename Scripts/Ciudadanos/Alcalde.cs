using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alcalde : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerPoints>().GetPlayerHasPrincess()) {
                GameObject.FindWithTag("Princesa").GetComponent<PrincesFollow>().ChangeParent("Alcalde");
                GameObject.FindWithTag("Player").GetComponent<PlayerPoints>().SetPlayerHasCombustible(true);
                GameObject.FindWithTag("Piloto").GetComponent<Piloto>().SetNewDialogue();
            }
        }
    }
}
