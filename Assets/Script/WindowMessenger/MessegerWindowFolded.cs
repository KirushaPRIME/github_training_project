using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MessegerWindowFolded : FoldedObjectScript
{

    private SpriteMask MessengerSpriteMask;

    public BlockMessengerButtonBehaviour BMBB;
    public SpriteMask Chat;
    public UnityEngine.UI.Mask StikerPackMask;
    public Transform StikerPack;
    //public GameObject EventSys;

    private void Awake()
    {
        MessengerSpriteMask = GetComponent<SpriteMask>();
    }
    void Start()
    {
        
    }
    protected override void WhenOpenWindow()
    {
        //Do if game open
        GetComponent<SpriteMask>().enabled = true;
        MessengerSpriteMask.enabled = true;
        Chat.enabled = true;
        StikerPackMask.enabled = true;
    }
    protected override void WhenFoldedWindow()
    {
        
        GetComponent<SpriteMask>().enabled = false;
        //Do if game folded
        MessengerSpriteMask.enabled = false;
        Chat.enabled = false;
        StikerPackMask.enabled = false;
    }
    public override void StopThisWindow()
    {
        for (int i = 0; i < StikerPack.childCount; i++)
        {
            StikerPack.GetChild(i).GetComponent<Button>().enabled = false;
        }
    }
    public override void StartThisWindow()
    {
        Button button;
        for (int i = 0; i < StikerPack.childCount; i++)
        {
            if (StikerPack.GetChild(i).TryGetComponent<Button>(out button))
            {
                button.enabled = true;
                Debug.Log(StikerPack.GetChild(i).name);
            }
        }
    }
}
