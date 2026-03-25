using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour
{
    public static int NamberForOpen;

    private void Awake()
    {
        GeneratorBehaviour.doneGEnerator += DoWhenDoneGen;
    }
    public void OpenGate()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("MustOpen", true);
    }
    public void DoWhenDoneGen(object Ob, EventArgs args)
    {
        Debug.Log("DoneGen: " + GeneratorBehaviour.CountDoneGane + " из " + NamberForOpen);
        if(GeneratorBehaviour.CountDoneGane >= NamberForOpen)
            OpenGate();
    }
}
