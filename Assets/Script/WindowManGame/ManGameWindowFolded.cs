using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManGameWindowFolded : FoldedObjectScript
{
    
    void Start()
    {
        
    }

    protected override void WhenOpenWindow()
    {
        KeyManager.SetControlInManGame(true);
        GetComponent<Mask>().enabled = true;
        //Debug.Log(KeyManager.GetControlInManGame());
    }

    protected override void WhenFoldedWindow()
    {
        KeyManager.SetControlInManGame(false);
        GetComponent<Mask>().enabled = false;
    }

    public override void StopThisWindow()
    {
        KeyManager.SetControlInManGame(false);
    }

    public override void StartThisWindow()
    {

    }
}
