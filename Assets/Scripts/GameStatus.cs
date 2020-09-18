using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config parameters
    [Range(0f,2f)] [SerializeField] float speed =1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText=default;

    //state variables
    [SerializeField] int currentScore = 0;

    
  
    private void Start()
    {
        scoreText.text = currentScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GameSpeed();
        

    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        
        

    }

    public void GameSpeed()
    {
        Time.timeScale = speed;
    }
}
