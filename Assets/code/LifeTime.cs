using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float timeToLive = 2;
    void Start()
    {
        Destroy(gameObject, timeToLive);
    }

}
