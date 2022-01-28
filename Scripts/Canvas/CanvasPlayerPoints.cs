using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPlayerPoints : MonoBehaviour
{
    private GameObject playerPoints;
    private TextMeshProUGUI pointsText;

    private void Start() {
        playerPoints = GameObject.FindWithTag("CanvasPoints");
        pointsText = GetComponent<TextMeshProUGUI>();
    }

    public void SetPoints(int points)
    {
        StartCoroutine(SetCanvasPoints(points));
    }

    public void RemovePoints(int totalPoints, int removePoints, int newPoints)
    {
        StartCoroutine(RemoveCanvasPoints(totalPoints, removePoints, newPoints));
    }

    IEnumerator SetCanvasPoints(int points)
    {
        pointsText.color = new Color(255, 196, 0);
        pointsText.text = "" + points;

        yield return new WaitForSeconds(2);

        pointsText.color = new Color(255, 255, 255);
    }

    IEnumerator RemoveCanvasPoints(int totalPoints, int removePoints, int newPoints)
    {
        pointsText.color = new Color(255, 0, 0);
        pointsText.text = "" + totalPoints + " - " + removePoints;

        yield return new WaitForSeconds(2);

        pointsText.text = "" + newPoints;
        pointsText.color = new Color(255, 255, 255);
    }
}
