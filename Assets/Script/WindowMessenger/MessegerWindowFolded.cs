using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessegerWindowFolded : FoldedObjectScript
{
    private SpriteMask MessengerSpriteMask;
    public SpriteMask Chat;
    public UnityEngine.UI.Mask StikerPack;

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
        MessengerSpriteMask.enabled = true;
        Chat.enabled = true;
        StikerPack.enabled = true;
    }
    protected override void WhenFoldedWindow()
    {
        //Do if game folded
        MessengerSpriteMask.enabled = false;
        Chat.enabled = false;
        StikerPack.enabled = false;
    }

}
