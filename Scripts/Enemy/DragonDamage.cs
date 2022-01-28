using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDamage : MonoBehaviour
{
    private DragonLife dragon;

    private void Start()
    {
        dragon = GetComponent<DragonLife>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet") {
            dragon.SetDragonHit(10);
        }
    }
}
