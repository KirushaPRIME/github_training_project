using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessegerWindowFolded : FoldedObjectScript
{
    private bool StopTheGame = true;
    private SpriteMask Messenger;
    private void Awake()
    {
        Messenger = GetComponent<SpriteMask>();
    }
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
                //Do if game folded
                Messenger.enabled = false;
            }
            if (CheakIMustOpen())
            {
                //Do if game open
                Messenger.enabled = true;
            }
        }
    }
}
