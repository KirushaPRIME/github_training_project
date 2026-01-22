using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoulArrow : MonoBehaviour
{
    private float LifeTime = 1;
    private float T;
    void Start()
    {
        T = Time.time;
    }
    void Update()
    {
        if (Time.time - T > LifeTime)
        {
            Destroy(gameObject);
        }
    }
    public void PlayerTry(float z)
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, z);
        
    }
}
