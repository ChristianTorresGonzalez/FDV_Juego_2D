using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPerks : MonoBehaviour
{
    private GameObject quickRevive;
    private GameObject doubleTap;
    private GameObject speedCola;

    private void Awake() {
        quickRevive = GameObject.FindWithTag("QuickReviveCanvas");
        doubleTap = GameObject.FindWithTag("DoubleTapCanvas");
        speedCola = GameObject.FindWithTag("SpeedColaCanvas");
    }

    public void InitializePerks()
    {
        quickRevive.SetActive(false);
    }

    public void SetPlayerPerk(string perk)
    {
        if (perk == "quickRevive") {
            quickRevive.SetActive(true);
        } else if (perk == "doubleTap") {
            doubleTap.SetActive(true);
        } else if (perk == "speedCola") {
            speedCola.SetActive(true);
        }
    }

    public void RemovePlayerPerk()
    {
        quickRevive.SetActive(false);
        doubleTap.SetActive(false);
        speedCola.SetActive(false);
    }
}
