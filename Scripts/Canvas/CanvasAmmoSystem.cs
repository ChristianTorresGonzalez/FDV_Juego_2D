using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasAmmoSystem : MonoBehaviour
{
    private TextMeshProUGUI ammoText;
    // public Gradient gradient;

    private void Start() {
        ammoText = GetComponent<TextMeshProUGUI>();
    }

    public void SetAmmo(int currentAmmo, int totalAmmo)
    {
       ammoText.text = "" + currentAmmo + "/" + totalAmmo;
    }

    public void SetNoAmmo(int currentAmmo, int totalAmmo)
    {
        StartCoroutine(SetNoWeaponAmmo(currentAmmo, totalAmmo));
    }

    IEnumerator SetNoWeaponAmmo(int currentAmmo, int totalAmmo)
    {
        ammoText.color = new Color(255, 0, 0);
        ammoText.text = "" + currentAmmo + "/" + totalAmmo;

        yield return new WaitForSeconds(0.40f);

        ammoText.color = new Color(255, 255, 255);
    }
}
