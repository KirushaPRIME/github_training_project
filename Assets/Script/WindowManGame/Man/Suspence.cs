using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspence : MonoBehaviour
{
    private float TrigerDistance = 35;
    public ManScript ManScript;
    public AudioSource Suspense;
    private bool Play = true;
    void Start()
    {
        
    }
    void Update()
    {
        if (TrigerDistance > Mathf.Abs(ManScript.GetRealDistance()))
        {
            if (!Play) {
                Suspense.Play();
                Play = true;
            }
            Suspense.volume = (TrigerDistance - Mathf.Abs(ManScript.GetRealDistance())) / TrigerDistance;
        }
        else
        {
            Suspense.Stop();
            Play = false;
        }
    }
}
