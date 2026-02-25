using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
 * Когда интернет отрубает или включается интернет вызываются следующие функции
 * 
 */

public class IntrernetCheak : ACrutchForInternet
{
    public SpriteRenderer LoadingScreen;
    public GameObject StikerPack;
    public GameObject Chat;
    public override void DoWhenConnection()
    {
        LoadingScreen.enabled = false;
        StikerPack.SetActive(true);
        Chat.SetActive(true);
        
    }
    public override void DoWhenDisconnection()
    {
        LoadingScreen.enabled = true;
        StikerPack.SetActive(false);
        Chat.SetActive(false);
    }
}
