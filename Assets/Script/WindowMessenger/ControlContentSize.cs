using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class ControlContentSize : MonoBehaviour
{
    private float ContentSizeY = 5;
    static private float ContentSizeX = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        ContentSizeX = transform.parent.GetComponentInParent<RectTransform>().sizeDelta.x;
        ContentSizeUpdate(0,0);
    }
    public void ContentSizeUpdate(float NewSizeX, float NewSizeY)
    {
        ContentSizeY += NewSizeY;
        GetComponent<RectTransform>().sizeDelta = new Vector2(NewSizeX, ContentSizeY);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, ContentSizeY);
    }
    public float GetContentSizeX() { return ContentSizeX; }
    public float GetContentSizeY() { return ContentSizeY; }
}
