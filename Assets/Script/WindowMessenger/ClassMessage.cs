using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMessage : MonoBehaviour
{
    private bool IsHaveParent;
    
    static private float Space = 1f;

    protected void AddMessage(RectTransform Messenge , float Width, float Height, RectTransform Parent)
    {
        //Debug.Log(HeightContent);
        ControlContentSize controlContentSize = Parent.GetComponent<ControlContentSize>();
        float NewWidth, NewHeight;
        if (controlContentSize != null)
        {
            
            NewWidth = Parent.rect.width - Space;
            NewHeight = Messenge.rect.height / Messenge.rect.width * Parent.rect.width - Space;
            Messenge.sizeDelta = new Vector2(NewWidth, NewHeight);
            controlContentSize.ContentSizeUpdate(0, NewHeight + Space);
            Messenge.anchoredPosition = new Vector2(0,
                -Parent.rect.height + NewHeight / 2 + Space);
        } else
        {
            Debug.Log("Родитель объекта " +  Messenge.name + " не имеет ControlContentSize");
        }
    }
}
