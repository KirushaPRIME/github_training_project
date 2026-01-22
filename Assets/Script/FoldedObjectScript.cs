using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FoldedObjectScript : MonoBehaviour
{
    protected bool IFolded = true;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    protected bool CheakIMustFolded()
    {
        if (WindowManager.GetFoldedObject() == gameObject && !IFolded)
        {
            IFolded = true;
            GetComponent<Canvas>().enabled = false;
            GetComponent<SpriteMask>().enabled = false;
            return true;
        }
        return false;
    }
    protected bool CheakIMustOpen()
    {
        if (WindowManager.GetOpenObject() == gameObject && IFolded)
        {
            IFolded = false;
            GetComponent<Canvas>().enabled = true;
            GetComponent<SpriteMask>().enabled = true;
            return true;
        }
        return false;
    }
}
