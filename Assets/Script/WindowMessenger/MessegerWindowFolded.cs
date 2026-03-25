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
    public UnityEngine.UI.Mask StikerPack;
    public EventSystem eventSystem;

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
        BMBB.Unblock();
        GetComponent<SpriteMask>().enabled = true;
        MessengerSpriteMask.enabled = true;
        Chat.enabled = true;
        StikerPack.enabled = true;
    }
    protected override void WhenFoldedWindow()
    {
        GetComponent<SpriteMask>().enabled = false;
        //Do if game folded
        MessengerSpriteMask.enabled = false;
        Chat.enabled = false;
        StikerPack.enabled = false;
    }
    public override void StopThisWindow()
    {
        BMBB.Block();
    }
}
