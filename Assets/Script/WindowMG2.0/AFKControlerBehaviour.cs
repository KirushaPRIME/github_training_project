using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFKControlerBehaviour : MonoBehaviour
{
    public static float MaxAFKTime;

    public ManBehaviour manBehaviour;

    private AudioSource audioSource;
    private float PauseTime = 5;
    private float RepiteTime = 0;
    public float AFKTime;
    void Start()
    {
        AFKTime = 0;
        audioSource = GetComponent<AudioSource>();
        InteractiveObjectBehaviour.StartInteraction += ResetAFKTime;
        MaxAFKTime = 40;
    }
    private void FixedUpdate()
    {
        AFKTime += Time.fixedDeltaTime;
        if (AFKTime > MaxAFKTime && RepiteTime < Time.time)
        {
            manBehaviour.WhinFailSkillCheak(this, new EventArgs());
            audioSource.Play();
            RepiteTime = Time.time + PauseTime;
        }
    }
    public void ResetAFKTime(object Ob, EventArgs args)
    {
        AFKTime = 0;
    }
}
