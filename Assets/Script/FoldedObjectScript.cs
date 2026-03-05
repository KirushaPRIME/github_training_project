using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FoldedObjectScript : MonoBehaviour
{
    protected bool StopTheGame = true;
    protected bool IMustFolded = false;
    protected bool IMustOpen = false;
    void Start()
    {
        
    }
    void Update()
    {
        /*
        if (WindowManager.GetWindowIsSelected())
        {
            if (!StopTheGame)
            {
                KeyManager.SetControlInManGame(false);
                //Debug.Log(KeyManager.GetControlInManGame());
                StopTheGame = true;
            }
        }
        else if (StopTheGame)
        {
            StopTheGame = false;
            if (CheakIMustFolded())
            {
                WhenFoldedWindow();
                
                //Debug.Log(KeyManager.GetControlInManGame());
            }
            if (CheakIMustOpen())
            {
                WhenOpenWindow();
                
            }
        }*/
    }
    protected virtual void WhenFoldedWindow() { }
    protected virtual void WhenOpenWindow() { }
    protected bool CheakIMustFolded()
    {
        if (IMustFolded)
        {
            IMustFolded = false;
            GetComponent<Canvas>().enabled = false;
            GetComponent<SpriteMask>().enabled = false;
            return true;
        }
        return false;
    }
    protected bool CheakIMustOpen()
    {
        if (IMustOpen)
        {
            IMustOpen = false;
            GetComponent<Canvas>().enabled = true;
            GetComponent<SpriteMask>().enabled = true;
            return true;
        }
        return false;
    }

    public virtual void DoWhenStartSelected()
    {

    }

    public virtual void DoWhenStopSelected()
    {

    }

    public void FoldedYourSelf()
    {
        WhenFoldedWindow();
        GetComponent<Canvas>().enabled = false;
        GetComponent<SpriteMask>().enabled = false;
        //IMustFolded = true;
    }
    public void OpenYourSelf()
    {
        WhenOpenWindow();
        GetComponent<Canvas>().enabled = true;
        GetComponent<SpriteMask>().enabled = true;
        //IMustOpen = true;
    }
}
