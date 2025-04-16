using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public GameObject titleCard;
    public GameObject gameOver;
    public GameObject startButton;
    public AudioSource source;
    public AudioClip getPoint;
    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.StartGame += HideTitleCard;
        ObstacleSlot.UpdateScore += OnUpdateScore;
    }

    private void OnUpdateScore(int obj)
    {
        if(obj > 0)
        {
            source.PlayOneShot(getPoint);
        }
    }

    void Start()
    {
        Vector3 titleCardPosition = titleCard.transform.position;
        titleCard.transform.position += Vector3.up * 1000;
        LeanTween.move(titleCard, titleCardPosition, 2f).setEaseInOutBack();   
        Vector3 startButtonPosition = startButton.transform.position;
        startButton.transform.position += Vector3.down * 1000;
        LeanTween.move(startButton, startButtonPosition, 1f).setDelay(2).setEaseInOutBack();   
    }

    private void HideTitleCard()
    {
        if(titleCard != null)
        {
            LeanTween.move(titleCard, titleCard.transform.position + Vector3.up * 1000, 0.5f).setEaseInBack();  
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
