using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessegerWindowFolded : FoldedObjectScript
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
                StopTheGame = true;
            }
        }
        else if (StopTheGame)
        {
            StopTheGame = false;
            if (CheakIMustFolded())
            {
            }
            if (CheakIMustOpen())
            {
            }
        }
    }
}
