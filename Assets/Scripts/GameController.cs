using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button restartButton; 
    public TextMeshProUGUI timerText;
    public Text counterText;
    private Spawner spawner;
    public bool isGameActive = false;
    private int time;

    public void StartGame()
    {
        DestroyAllBalls();
        isGameActive = true;
        counterText.text = "Count : 0";
        restartButton.gameObject.SetActive(false);
        StartCoroutine(Timer());
        GameObject spawnerObject = GameObject.Find("Spawner");
        spawner = spawnerObject.GetComponent<Spawner>();
        spawner.CreateBallInstance(2);
    }

    IEnumerator Timer()
    {
        time = 60;
        timerText.text = "Time: " + time;
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time -= 1;
            timerText.text = "Time: " + time;
        }
        GameOver();
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    private void DestroyAllBalls()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Ball");

        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
    }

}
