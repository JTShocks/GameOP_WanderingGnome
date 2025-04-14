using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JT.Enums;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{

    public const float WORLD_MOVE_SPEED = 0.1f;
    public const float GLOBAL_COLUMN_SPEED = 1;
    /*
        Tracking the score of the player as they progress through the round.
        
    */

    public static Action StartGame;
    public static Action GameOver;
    public float columnIntervalSeconds;
    float targetTime = 1;

    public TextMeshProUGUI scoreDisplay;
    
    public int currentScore;

    bool gameIsStarted;

    void OnEnable()
    {
        ObstacleSlot.UpdateScore += OnUpdateScore;
    }
    void OnDisable()
    {
        
    }

    private void OnUpdateScore(int value)
    {
        currentScore += value;
        currentScore = Mathf.Max(0, currentScore);
        scoreDisplay.text = currentScore.ToString();
        
        if(value < 0)
        {
            OnGameOver();
        }
        //Debug.Log("Score has updated");
    }


    void OnGameOver()
    {
        gameIsStarted = false;
        GameOver.Invoke();
    }

    public void OnGameStart()
    {
        StartGame.Invoke();
        ActivateNewLine();
        targetTime = columnIntervalSeconds;
        gameIsStarted = true;
        
    }

    void Update()
    {
        if(!gameIsStarted)
        {
            return;
        }
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
            {
            OnTimerStopped();
            }
    }

    private void OnTimerStopped()
    {
        ActivateNewLine();
        targetTime = columnIntervalSeconds;
    }

    void ActivateNewLine()
    {
        GameObject nextLine = ObjectPool.SharedInstance.GetPooledObject();
        nextLine.transform.position = transform.position;


        ObstacleColumn column = nextLine.GetComponent<ObstacleColumn>();
        column.scrollSpeed = GLOBAL_COLUMN_SPEED;
        column.OnActivate();
    }



    


    

}
