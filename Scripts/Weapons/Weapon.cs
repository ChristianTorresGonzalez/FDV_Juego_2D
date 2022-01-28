using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private GameObject bulletPrefab;
    public string weaponName;
    private int totalAmmo;
    private int damageBullet;
    private int currentAmmo;
    private int ammoMagazine;
    private int reloadTime;

    public void InitializeWeapon(GameObject bPrefab = null, string name = "Pistol", int tAmmo = 70, int cAmmo = 8, int aMagazine = 8, int dBullet = 1, int rTime = 3)
    {
        if (bPrefab == null) {
            bulletPrefab = GameObject.FindWithTag("Bullet");
        } else {
            bulletPrefab = bPrefab;
        }

        weaponName = name;
        totalAmmo = tAmmo;
        currentAmmo = cAmmo;
        ammoMagazine = aMagazine;
        damageBullet = dBullet;
        reloadTime = rTime;
    }

    public void ShootWeapon()
    {
        if (currentAmmo > 0) {
            currentAmmo--;
        } else {
            if (totalAmmo > ammoMagazine) {
                currentAmmo = ammoMagazine;
                totalAmmo -= ammoMagazine;
            } else {
                currentAmmo = totalAmmo;
                totalAmmo = 0;
            }
        }
    }

    public void ReloadWeapon()
    {
        totalAmmo += currentAmmo;
        totalAmmo -= ammoMagazine;
        currentAmmo = ammoMagazine;
    }

    public void SetWeaponName(string name)
    {
        weaponName = name;
    }

    public string GetWeaponName()
    {
        return weaponName;
    }

    public int GetCurrentWeaponAmmo()
    {
        return currentAmmo;
    }

    public int GetTotalWeaponAmmo()
    {
        return totalAmmo;
    }

    public int GetWeaponAmmoMagazine()
    {
        return ammoMagazine;
    }

    public int GetReloadTime()
    {
        return reloadTime;
    }

    public GameObject GetBulletPrefab()
    {
        return bulletPrefab;
    }

    public void SetWeaponAmmo(int ammo)
    {
        totalAmmo += ammo;
    }
}