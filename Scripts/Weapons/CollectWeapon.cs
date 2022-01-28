using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWeapon : MonoBehaviour
{
    private GameObject bulletPrefab;
    private Weapon weaponFusil;
    private string name;
    private int totalAmmo;
    private int currentAmmo;
    private int ammoMagazine;
    private int damageBullet;
    private int reloadTime;

    private void Start()
    {
        weaponFusil = GameObject.FindWithTag("FusilBullet").GetComponent<Weapon>();
        bulletPrefab = GameObject.FindWithTag("FusilBullet");
        name = "M4";
        totalAmmo = 150;
        currentAmmo = 30;
        ammoMagazine = 30;
        damageBullet = 10;
        reloadTime = 10;        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == GameObject.FindWithTag("Player").tag) {
            weaponFusil.InitializeWeapon(bulletPrefab, name, totalAmmo, currentAmmo, ammoMagazine, damageBullet, reloadTime);
            
            GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().ChangeWeapon(weaponFusil);
        }
    }
}
