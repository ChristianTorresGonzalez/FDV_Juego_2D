using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public float velocidad_movimiento;
    public float velocidad_rotacion;

    public float ejeX;
    public float ejeY;
    public float ejeZ;

    public float poder;

    void Start()
    {
        velocidad_movimiento = 0.01f;
        velocidad_rotacion = 0.5f;

        poder = 1000f;
    }

    void Update()
    {
        ejeX = gameObject.transform.position.x;
        ejeY = gameObject.transform.position.y;
        ejeZ = gameObject.transform.position.z;

        if (GetComponent<PlayerLife>().GetPlayerAlive()) {
            if (Input.GetKey("l"))
            {
                transform.position = new Vector3(ejeX + (1 * velocidad_movimiento), ejeY, ejeZ);
            }

            if (Input.GetKey("j"))
            {
                transform.position = new Vector3(ejeX - (1 * velocidad_movimiento), ejeY, ejeZ);
            }

            if (Input.GetKey("i"))
            {
                transform.position = new Vector3(ejeX, ejeY + (1 * velocidad_movimiento), ejeZ);
            }

            if (Input.GetKey("k"))
            {
                transform.position = new Vector3(ejeX, ejeY - (1 * velocidad_movimiento), ejeZ);
            }
        }
    }
}
