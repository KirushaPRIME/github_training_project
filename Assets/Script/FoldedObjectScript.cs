using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoldedObjectScript : MonoBehaviour
{
    protected bool IMustFolded = false;
    protected bool IMustOpen = false;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
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
    public void FoldedYourSelf()
    {
        IMustFolded = true;
    }
    public void OpenYourSelf()
    {
        IMustOpen = true;
    }
}
