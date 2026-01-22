using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManGameWindowFolded : FoldedObjectScript
{
    private bool StopTheGame = true;
    void Start()
    {
        
    }
    void Update()
    {
        if (WindowManager.GetWindowIsSelected())
        {
            if (!StopTheGame)
            {
                KeyManager.SetControlInManGame(false);
                Debug.Log(KeyManager.GetControlInManGame());
                StopTheGame = true;
            }
        } else if (StopTheGame)
        {
            StopTheGame = false;
            if (CheakIMustFolded())
            {
                KeyManager.SetControlInManGame(false);
                Debug.Log(KeyManager.GetControlInManGame());
            }
            if (CheakIMustOpen())
            {
                KeyManager.SetControlInManGame(true);
                Debug.Log(KeyManager.GetControlInManGame());
            }
        }
        //Debug.Log(false);
    }
}
