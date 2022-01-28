using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerks : MonoBehaviour
{
    public ControladorDelegados controlador;
    private bool doubleTap;
    private bool speedCola;
    private bool quickRevive;

    void Start()
    {
        GameObject.FindWithTag("QuickReviveCanvas").SetActive(false);
        GameObject.FindWithTag("DoubleTapCanvas").SetActive(false);
        GameObject.FindWithTag("SpeedColaCanvas").SetActive(false);
        
        doubleTap = false;
    }

    void OnEnable()
    {
        controlador.ActivePlayerPerk += ActivePlayerPerk;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerPerk -= ActivePlayerPerk;
    }

    private void ActivePlayerPerk(string perk)
    {
        if (perk == "doubleTap") {
            doubleTap = true;
            GameObject.FindWithTag("PerksCanvas").GetComponent<CanvasPerks>().SetPlayerPerk("doubleTap");
        } else if (perk == "speedCola") {
            speedCola = true;
            GameObject.FindWithTag("PerksCanvas").GetComponent<CanvasPerks>().SetPlayerPerk("speedCola");
        } else if (perk == "quickRevive") {
            quickRevive = true;
            GameObject.FindWithTag("PerksCanvas").GetComponent<CanvasPerks>().SetPlayerPerk("quickRevive");
        }
    }

    public bool GetDoubleTap()
    {
        return doubleTap;
    }

    public bool GetSpeedCola()
    {
        return speedCola;
    }

    public bool GetQuickRevive()
    {
        return quickRevive;
    }

    public void RemovePlayerPerk()
    {
        doubleTap = false;
        speedCola = false;
        quickRevive = false;
    }
}
