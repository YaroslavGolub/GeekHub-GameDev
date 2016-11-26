using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public float timeBeforeScoreShown = 5.0f;
    public float timeToReload = 2.0f;
    public GameObject[] Walls;

    public GameObject scorePanel;
    public Text scorePanelText;

    private void Start()
    {
        scorePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
            TurnTheWalls();
        UpdateScore();
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(timeBeforeScoreShown);
        ShowScorePanel();  
    }

    public void UpdateScore()
    {
        scoreText.text = CountScore().ToString();

        if (CountScore() == 10f)
        {
            ShowScorePanel();
        }
    }

    private void ShowScorePanel()
    {
        scorePanel.SetActive(true);
        scorePanelText.text = " Your score : " + CountScore();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private int CountScore()
    {
        int fallen = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsFallen())
            {
                fallen++;
            }
        }
        return fallen;
    }

    public void TurnTheWalls()
    {
        foreach (GameObject go in Walls)
        {
            go.SetActive(!go.activeInHierarchy);
        }
        if (Walls[0].activeInHierarchy)
            Debug.Log("Guardrails enabled");
        else
            Debug.Log("Guardrails disabled");
    }

}
