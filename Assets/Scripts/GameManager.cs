using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;

    private int score;
    private float spawnRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("TitleScreen");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);

            Instantiate(targets[index]);     
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        Debug.Log(SceneManager.GetActiveScene().name + " was clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StarGame(int difficulty)
    {
        score = 0;
        isGameActive = true;
        spawnRate /= difficulty;

        Debug.Log("Spawn rate: " + spawnRate);
        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawTarget());
        UpdateScore(0);

    }
}
