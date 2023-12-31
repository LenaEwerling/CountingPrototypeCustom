using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] balls;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.Find("GameController");
        gameController = gameControllerObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBallInstance(int comesFrom)
    {
        Debug.Log(comesFrom);
        if (gameController.isGameActive)
        {
            int ball = Random.Range(0, balls.Length);
            GameObject instantiatedball = Instantiate(balls[ball]);

            float y = Random.Range(2f, 8f);

            // Optionally, you can set the position, rotation, and parent of the instantiated prefab
            instantiatedball.transform.position = new Vector3(10f, y, 0f);
        }
        
    }
}
