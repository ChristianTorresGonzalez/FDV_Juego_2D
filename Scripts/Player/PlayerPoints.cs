using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public ControladorDelegados controlador;
    public GameObject pointsCanvas;
    private int playerPoints;
    private bool hasPrincess;
    private bool hasCombustible;

    void Start()
    {
        pointsCanvas = GameObject.FindWithTag("CanvasPoints");
        playerPoints = 500;
        hasPrincess = false;
        hasCombustible = false;
    }

    void OnEnable()
    {
        controlador.ActivePlayerPoints += SetPlayerPoints;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerPoints -= SetPlayerPoints;
    }

    private void SetPlayerPoints(int points)
    {
        playerPoints += points;
        
        SetCanvasPlayerPoints();
    }

    public void SetPlayerHasPrincess(bool princes)
    {
        hasPrincess = princes;
    }

    public void SetPlayerHasCombustible(bool combustible)
    {
        hasCombustible = combustible;
    }

    public bool GetPlayerHasPrincess()
    {
        return hasPrincess;
    }

    public bool GetPlayerHasCombustible()
    {
        return hasCombustible;
    }

    public void RemovePlayerPoints(int points)
    {
        playerPoints -= points;
        
        SetCanvasPlayerPoints();
    }

    public void BuyPlayerPoints(int points)
    {
        playerPoints -= points;
        
        pointsCanvas.GetComponent<CanvasPlayerPoints>().RemovePoints(playerPoints + points, points, playerPoints);
    }

    private void SetCanvasPlayerPoints()
    {
        pointsCanvas.GetComponent<CanvasPlayerPoints>().SetPoints(playerPoints);
    }

    public int GetPlayerPoints()
    {
        return playerPoints;
    }
}
