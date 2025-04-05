using System.Collections;
using System.Collections.Generic;
using JT.Enums;
using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;

[CreateAssetMenu]
public class Obstacle : ScriptableObject
{

    public Obstacles ObstacleType = Obstacles.Empty;
    public Sprite ObstacleSprite;
    public int PointValue;


}
