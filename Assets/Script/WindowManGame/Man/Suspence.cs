using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspence : MonoBehaviour
{
    public float TrigerDistance = 35;
    public ManScript ManScript;
    public AudioSource Suspense;
    private bool SuspenceIsActive = false;
    private bool Play = true;
    void Start()
    {
        
    }
    void Update()
    {
        if (TrigerDistance > Mathf.Abs(ManScript.GetRealDistance() * 1 / ManScript.GetScaleDistance()))
        {
            if (!Play) {
                Suspense.Play();
                Play = true;
            }
            Suspense.volume = (TrigerDistance - Mathf.Abs(ManScript.GetRealDistance() * 1 / ManScript.GetScaleDistance())) / TrigerDistance;
        }
        else
        {
            Suspense.Stop();
            Play = false;
        }
    }
    public void SuspenceOn() { SuspenceIsActive = true; }
    public void SuspenceOff() { SuspenceIsActive = false; }
}
