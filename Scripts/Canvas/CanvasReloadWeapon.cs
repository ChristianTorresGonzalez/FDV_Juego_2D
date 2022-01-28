using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasReloadWeapon : MonoBehaviour
{
    public GameObject reloadBar;
    public Slider slider;

    private void Awake() {
        slider = reloadBar.GetComponent<Slider>();
    }

    public void InitializeReload()
    {
        reloadBar.SetActive(false);
    }

    public void ReloadWeapon(int reloadTime)
    {
        reloadBar.SetActive(true);

        StartCoroutine(ReloadWaponAmmo(reloadTime));
    }

    IEnumerator ReloadWaponAmmo(int reloadTime)
    {
        reloadTime *= 100;
        slider.maxValue = reloadTime;

        int counter = 0;
        while(counter < reloadTime) {
            slider.value = counter;

            counter++;
            
            yield return new WaitForSeconds(0.01f);
        }

        reloadBar.SetActive(false);
    }
}
