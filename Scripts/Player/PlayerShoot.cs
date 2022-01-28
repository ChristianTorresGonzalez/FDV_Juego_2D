using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public ControladorDelegados controlador;
    private GameObject ammoCanvas;
    public GameObject reloadCanvas;
    private GameObject playerPrefab;
    public GameObject bulletPrefab;
    public Weapon currentWeapon;
    public float shootDelay;
    private float lastShoot;
    public bool isReloading;

    void Start()
    {
        playerPrefab = GameObject.FindWithTag("Player");
        ammoCanvas = GameObject.FindWithTag("CanvasAmmo");
        reloadCanvas = GameObject.FindWithTag("ReloadBar");
        
        reloadCanvas.GetComponent<CanvasReloadWeapon>().InitializeReload();
        currentWeapon.InitializeWeapon();
        
        SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());

        shootDelay = 0.25f;
    }

    void OnEnable()
    {
        controlador.ActivePlayerWeapon += ChangeWeapon;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerWeapon -= ChangeWeapon;
    }

    void Update()
    {
        if (GetComponent<PlayerLife>().GetPlayerAlive()) {
            if (Input.GetMouseButtonDown(0) && Time.time > lastShoot + shootDelay) {
                if (currentWeapon.GetCurrentWeaponAmmo() > 0) {
                    lastShoot = Time.time;
                    
                    ShootBullet();

                    if (playerPrefab.GetComponent<PlayerPerks>().GetDoubleTap()) {
                        Invoke("ShootBullet", 0.1f);
                    }
                    
                    currentWeapon.ShootWeapon();

                    SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
                } else {
                    ammoCanvas.GetComponent<CanvasAmmoSystem>().SetNoAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
                }
            }

            if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentWeapon.GetCurrentWeaponAmmo() != currentWeapon.GetWeaponAmmoMagazine()) {
                isReloading = true;
                StartCoroutine(ReloadWeapon());
            }
        }
    }

    IEnumerator ReloadWeapon()
    {
        int rTime = currentWeapon.GetReloadTime();

        if (playerPrefab.GetComponent<PlayerPerks>().GetSpeedCola()) {
            rTime /= 3;
        }

        reloadCanvas.GetComponent<CanvasReloadWeapon>().ReloadWeapon(rTime);

        yield return new WaitForSeconds(rTime);

        currentWeapon.ReloadWeapon();

        SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
        isReloading = false;
    }

    public void ChangeWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
    }

    private void ShootBullet()
    {        
        Vector2 lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (new Vector2(this.transform.position.x, this.transform.position.y) - lastClickedPos).normalized;
        
        lastClickedPos = lastClickedPos + direction * (-100);
        
        GameObject bullet = Instantiate(currentWeapon.GetBulletPrefab(), new Vector2(this.transform.position.x, this.transform.position.y) + (direction * (-1f)), Quaternion.identity);

        bullet.GetComponent<BulletScript>().SetOrientation(lastClickedPos);
        bullet.GetComponent<BulletScript>().ShootBullet();
    }

    private void SetCanvasAmmo(int currentAmmo, int totalAmmo)
    {
        ammoCanvas.GetComponent<CanvasAmmoSystem>().SetAmmo(currentAmmo, totalAmmo);
    }

    public void SetAmmoWeapon(int ammo)
    {
        currentWeapon.SetWeaponAmmo(ammo);
        SetCanvasAmmo(currentWeapon.GetCurrentWeaponAmmo(), currentWeapon.GetTotalWeaponAmmo());
    }
}
