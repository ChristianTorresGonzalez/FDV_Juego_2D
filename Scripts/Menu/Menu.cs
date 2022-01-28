using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }

    public void PlayGame()
    {
        StartCoroutine(StartGame());
    }

    public IEnumerator StartGame()
    {
        panel.SetActive(true);
        
        panel.GetComponent<FadeInOut>().SetFadeIn();
        yield return new WaitForSeconds(1.8f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
