using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassMessage : MonoBehaviour
{
    private bool IsHaveParent;
    
    static private float Space = 1f;
    void Start()
    {
        
    }
    private void CheakHaveParent()
    {

    }
    void Update()
    {
        
    }
    protected void AddMessage(GameObject Messenge , float Width, float Height, GameObject Parent)
    {
        //Debug.Log(HeightContent);
        ControlContentSize controlContentSize = Parent.GetComponent<ControlContentSize>();
        if (controlContentSize != null)
        {
            float HeightContent = controlContentSize.GetContentSizeY() + Height + Space;
            Messenge.transform.GetChild(0).gameObject.GetComponentsInChildren<SpriteRenderer>()[0].size = new Vector2(controlContentSize.GetContentSizeX(), Height + Space * 0.9f);
            controlContentSize.ContentSizeUpdate(0, HeightContent);
            Messenge.GetComponent<Transform>().localPosition = new Vector2(0, -HeightContent / 2 + (Height + Space * 0.9f) / 2);
        } else
        {
            Debug.Log("Родитель объекта " +  Messenge.name + " не имеет ControlContentSize");
        }
    }
}
