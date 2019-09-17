using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    private int count;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;

        restartText.text = "";
        gameOverText.text = "";

        //IEn~ 꼴로 된 함수를 호출 할 때
        StartCoroutine (SpawnWaves());
        UpdateScore();
        count = 0;
    }

    private void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown (KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    //coroutine이 되기 위해서는 IE~ 를 반환해야 한다.)

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart!";
                restart = true;
                break;
            }

        }
    }

	// Use this for initialization
	
    public void AddScore (int newScoreValue)
    {
        count += newScoreValue;
        UpdateScore();
    }
	
	// Update is called once per frame
	void UpdateScore ()
    {
        ScoreText.text = "Score: " + count.ToString();

    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
