using System.Collections;
using System.Collections.Generic;
using JT.Enums;
using UnityEngine;

public class ObstacleColumn : MonoBehaviour
{
    public List<ObstacleSlot> slots;
    public float scrollSpeed;


    bool hasRock = false;
    bool hasCrop = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isActiveAndEnabled)
        {
            //Move the column to the left
            transform.position += new Vector3(-scrollSpeed, 0) * Time.deltaTime;
            if(transform.position.x <= -12)
            {
                gameObject.SetActive(false);
            }
        }

    }


    public void OnActivate()
    {
        hasRock = false;
        hasCrop = false;
        int i = 0;
        //Randomly choose 
        while(i < 3)
        {
            Obstacles thisObstacle = slots[i].AssignObstacle();
            switch(thisObstacle)
            {
                case Obstacles.Rock:
                    if(!hasRock)
                    {
                        hasRock = true;
                        i++;
                    }
                    else if(hasCrop)
                    {
                        i++;
                    }
                break;
                case Obstacles.Crop:
                    if(!hasCrop)
                    {
                        hasCrop = true;
                    }
                    i++;
                break;
                case Obstacles.Empty:
                    if(hasCrop)
                    {
                        i++;
                    }
                break;
            }
        }

        gameObject.SetActive(true);
    }
}
