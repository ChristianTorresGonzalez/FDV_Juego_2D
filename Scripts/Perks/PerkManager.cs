using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PerkManager
{
    public ControladorDelegados controlador;
    private GameObject player;
    private GameObject perkMachine;
    private int quickRevivePoints;
    private int doubleTapPoints;
    private int speedColaPoints;
    private int ammoPoints;
    private bool perkBought;
    private string buyPerkText;

    public void InitializePerksPrice()
    {
        quickRevivePoints = 500;
        doubleTapPoints = 2500;
        speedColaPoints = 3000;
        ammoPoints = 100;
    }

    public void BuyPlayerPerk(GameObject pMachine, string perk)
    {
        player = GameObject.FindWithTag("Player");
        perkMachine = pMachine;
        controlador = GameObject.FindWithTag("MainCamera").GetComponent<ControladorDelegados>();

        if (perk == "QuickRevive") {
            if (player.GetComponent<PlayerPerks>().GetQuickRevive()) {
                buyPerkText = "Ya tienes comprado QuickRevive";
            } else if (player.GetComponent<PlayerPoints>().GetPlayerPoints() >= quickRevivePoints) {
                controlador.SetPlayerPerk("quickRevive");
                player.GetComponent<PlayerPoints>().BuyPlayerPoints(quickRevivePoints);
                
                buyPerkText = "Has comprado QuickRevive por " + quickRevivePoints + "puntos";
            } else {
                buyPerkText = "No dispones de puntos suficientes para comprar QuickRevive";
            }
        } else if (perk == "DoubleTap") {
            if (player.GetComponent<PlayerPerks>().GetDoubleTap()) {
                buyPerkText = "Ya tienes comprado DoubleTap";
            } else if (player.GetComponent<PlayerPoints>().GetPlayerPoints() >= doubleTapPoints) {
                controlador.SetPlayerPerk("doubleTap");
                player.GetComponent<PlayerPoints>().BuyPlayerPoints(doubleTapPoints);
                
                buyPerkText = "Has comprado DoubleTap por " + doubleTapPoints + "puntos";
            } else {
                buyPerkText = "No dispones de puntos suficientes para comprar DoubleTap";
            }
        } else if (perk == "SpeedCola") {
            if (player.GetComponent<PlayerPerks>().GetDoubleTap()) {
                buyPerkText = "Ya tienes comprado SpeedCola";
            } else if (player.GetComponent<PlayerPoints>().GetPlayerPoints() >= speedColaPoints) {
                controlador.SetPlayerPerk("speedCola");
                player.GetComponent<PlayerPoints>().BuyPlayerPoints(speedColaPoints);
                
                buyPerkText = "Has comprado SpeedCola por " + speedColaPoints + "puntos";
            } else {
                buyPerkText = "No dispones de puntos suficientes para comprar SpeedCola";
            }
        } else if (perk == "Ammo") {
            if (player.GetComponent<PlayerPoints>().GetPlayerPoints() >= ammoPoints) {
                player.GetComponent<PlayerShoot>().SetAmmoWeapon(10);
                player.GetComponent<PlayerPoints>().BuyPlayerPoints(ammoPoints);
                buyPerkText = "Has comprado 10 balas de Municion por " + ammoPoints + "puntos";
            } else {
                buyPerkText = "No dispones de puntos suficientes para comprar munición";
            }
        }

        perkMachine.GetComponent<DialogueManager>().DisplayNewText(buyPerkText);
    }
}
