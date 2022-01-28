using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piloto : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            Debug.Log(GameObject.FindWithTag("Player").GetComponent<PlayerPoints>().GetPlayerHasCombustible());
            if (GameObject.FindWithTag("Player").GetComponent<PlayerPoints>().GetPlayerHasCombustible()) {
               
            }
        }
    }

    public void SetNewDialogue()
    {
        string[] sentences = new string[] {
                "Buenas capitan.",
            "Veo que ha conseguido el combustible necesario para que funcione el barco",
            "Perfecto, rellenare los depositos y nos pondremos en marcha",
            "A la orden capitan, que tenga buen dia"
        };

        GetComponent<DialogueManager>().SetNewSentences(sentences);
    }
}
