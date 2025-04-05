using System;
using System.Collections;
using System.Collections.Generic;
using JT.Enums;
using UnityEngine;

public class ObstacleSlot : MonoBehaviour
{

    public List<Obstacle> obstacles;
    public Obstacle currentObstacle;

    public SpriteRenderer spriteRenderer;
    [SerializeField]
    GameObject shadow;

    public static Action<int> UpdateScore;

    public Obstacles AssignObstacle()
    {
        int rng = UnityEngine.Random.Range(0,obstacles.Count - 1);

        currentObstacle = obstacles[rng];
        spriteRenderer.sprite = currentObstacle.ObstacleSprite;
        if(currentObstacle.ObstacleType == Obstacles.Rock)
        {
            spriteRenderer.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        }
        else
        {
            spriteRenderer.gameObject.transform.rotation = Quaternion.Euler(0,0,-45);
        }

        if(currentObstacle.ObstacleType == Obstacles.Empty)
        {
            shadow.SetActive(false);
        }
        else
        {
            shadow.SetActive(true);
        }

        gameObject.SetActive(true);
        return obstacles[rng].ObstacleType;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Made contact.");
        UpdateScore.Invoke(currentObstacle.PointValue);
        gameObject.SetActive(false);
    }

}
