using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounceTween : MonoBehaviour
{

    [SerializeField]
    float scaleFactor = 1.25f;
    void OnEnable()
    {
        LeanTween.scale(gameObject, new Vector3(scaleFactor, scaleFactor, scaleFactor), 1f).setLoopPingPong().setEase(LeanTweenType.punch);
    }

}
