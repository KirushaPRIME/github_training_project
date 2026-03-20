using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowMG2dot0Folded : FoldedObjectScript
{
    public SurvBehaviour survBehaviour;
    public GameObject MG2dot0Camera;
    public GameObject GlobalCamera;
    public GameObject AllObject;
    public Mask mask;
    public Image MaskImage;
    public SpriteMask spriteMask;
    public SpriteMask WindowSpriteMask;

    protected override void WhenOpenWindow()
    {
        mask.enabled = false;
        //spriteMask.enabled = false;
        MaskImage.enabled = false;
        WindowSpriteMask.enabled = true;
        survBehaviour.CanMove = true;
        MG2dot0Camera.SetActive(true);
        GlobalCamera.SetActive(false);
    }
    protected override void WhenFoldedWindow()
    {
        survBehaviour.CanMove = false;
    }
    public override void StopThisWindow()
    {
        
        survBehaviour.CanMove = false;
        AllObject.GetComponent<Transform>().localPosition =
            new Vector2(
                -MG2dot0Camera.GetComponent<Transform>().localPosition.x,
                AllObject.GetComponent<Transform>().localPosition.y
            );
        mask.enabled = true;
        //spriteMask.enabled = true;
        MaskImage.enabled = true;
        WindowSpriteMask.enabled = true;
        MG2dot0Camera.SetActive(false);
        GlobalCamera.SetActive(true);
    }
}
