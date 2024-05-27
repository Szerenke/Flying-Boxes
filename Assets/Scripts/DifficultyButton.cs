using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button difficultyButton;
    private GameManager gameManager;
    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficultyButton = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyButton.onClick.AddListener(SetDifficoulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficoulty()
    {
        gameManager.StarGame(difficulty);
    }
}
