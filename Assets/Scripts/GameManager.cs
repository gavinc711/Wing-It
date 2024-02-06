using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyTwoPrefab;
	public GameObject enemyThreePrefab;
	public GameObject bossPrefab;
	public GameObject cloudPrefab;
	public GameObject gameOverSet;
	public GameObject winSet;
	public GameObject[] thingsThatSpawn;
    public int score;
    public int cloudsMove;
	public int enemyCount;
	public int round;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
	public TextMeshProUGUI roundText;
	private bool isGameOver;
	private bool isDone;
 
    // Start is called before the first frame update
    void Start()
    {
		round = 1;
		cloudsMove = 1;
        score = 0;
		isGameOver = false;
		
        scoreText.text = "Score: 0";
		livesText.text = "Lives: 3";
		
		Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
		RoundStart();
    }

    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene("Game");
        }
		
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
		
		if (!isDone)
		{
			if (enemyCount == 49)
			{
				CancelInvoke("CreateEnemyOne");
				CancelInvoke("CreateEnemyTwo");
				CancelInvoke("CreateEnemyThree");
				CreateBoss();
				isDone = true;
			}
		}
		
		if (round >= 3)
		{
			Win();
		}
    }
	
	IEnumerator RoundText()
	{
		roundText.enabled = true;
		yield return new WaitForSeconds(3);
		roundText.enabled = false;
	}
	
	public void RoundStart()
	{
		enemyCount = 0;
		isDone = false;
		
		InvokeRepeating("CreateEnemyOne", 1.0f, 4.0f);
        InvokeRepeating("CreateEnemyTwo", 4.0f, 5.0f);
		InvokeRepeating("SpawnSomething", 5f, 20f);
		
		if (round == 2)
			InvokeRepeating("CreateEnemyThree", 7.0f, 6.0f);
		
		if (round < 3)
		{
			roundText.text = "ROUND " + round;
			StartCoroutine(RoundText());
		}
	}

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateEnemyTwo()
    {
        Instantiate(enemyTwoPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }
	
	void CreateEnemyThree()
    {
        Instantiate(enemyThreePrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }
	
	void CreateBoss()
    {
        Instantiate(bossPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }
	
	void CreateSky()
    {
        for (int i = 0; i < 50; i++) 
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-11f, 11f), Random.Range(-7.5f, 7.5f), 0), Quaternion.identity);
        }
    }
	
	void SpawnSomething()
    {
        int tempInt;
        tempInt = Random.Range(0, 3);
        Instantiate(thingsThatSpawn[tempInt], new Vector3(Random.Range(-7f, 7f), Random.Range(0, -5f), 0), Quaternion.identity);
    }
	
	public void GameOver()
    {
        CancelInvoke();
        cloudsMove = 0;
        gameOverSet.SetActive(true);
        isGameOver = true;
    }
	
	public void Win()
	{
		CancelInvoke();
		winSet.SetActive(true);
		isGameOver = true;
	}

    public void EarnScore(int scoreToAdd)
    {
		if (score < 999)
		{
			score = score + scoreToAdd;
			scoreText.text = "Score: " + score;
		}
		else
			scoreText.text = "Score: 999";
    }
	
	public void IncreaseEnemyCount()
	{
		enemyCount += 1;
	}
	
	public void LivesChange(int currentLife)
	{
		livesText.text = "Lives: " + currentLife;
	}
}
