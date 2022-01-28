using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    public ControladorDelegados controlador;
    private GameObject healthCanvas;
    private GameObject reviveCanvas;
    private Slider slider;
    private Animator animator;
    private int maxHits;
    private int playerHits;
    private int reviveTime;
    private static bool playerAlive;

    void Start()
    {
        healthCanvas = GameObject.FindWithTag("CanvasHealth");
        reviveCanvas = GameObject.FindWithTag("ReviveBar");

        healthCanvas.GetComponent<CanvasLifeSystem>().SetMaxHealth();
        reviveCanvas.GetComponent<CanvasPlayerRevive>().InitializeRevive();
        animator = GetComponent<Animator>();

        maxHits = 3;
        playerHits = 0;
        reviveTime = 10;
        playerAlive = true;
    }

    void OnEnable()
    {
        controlador.ActivePlayerHit += SetPlayerHit;
    }

    void OnDeseable()
    {
        controlador.ActivePlayerHit -= SetPlayerHit;
    }

    public void SetPlayerHit()
    {
        playerHits++;

        healthCanvas.GetComponent<CanvasLifeSystem>().SetHealth(maxHits - playerHits, maxHits);

        CheckPlayerHits();
    }

    private void CheckPlayerHits()
    {
        if (playerHits == maxHits) {
            if (GetComponent<PlayerPerks>().GetQuickRevive()) {
                SetPlayerDead();
                StartCoroutine(RevivePlayer());
                
                reviveCanvas.GetComponent<CanvasPlayerRevive>().RevivePlayer(reviveTime);
                healthCanvas.GetComponent<CanvasLifeSystem>().SetMaxHealth();

                GetComponent<PlayerPerks>().RemovePlayerPerk();
            } else {
                SetPlayerDead();
                animator.SetBool("playerDead", true);
                GetComponent<SpriteRenderer>().size = new Vector2(0.5f, .44f);

                StartCoroutine(EndGame());
            }
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);

        GameObject panel = GameObject.FindWithTag("PanelJuego");
        panel.GetComponent<FadeInOut>().SetFadeIn();

        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SetPlayerDead()
    {
        playerAlive = false;
    }

    private IEnumerator RevivePlayer()
    {
        yield return new WaitForSeconds(reviveTime + 0.5f);
        
        playerHits = 0;
        playerAlive = true;
    }

    public bool GetPlayerAlive()
    {
        return playerAlive;
    }
}
