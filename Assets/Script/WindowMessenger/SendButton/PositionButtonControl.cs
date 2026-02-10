using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionButtonControl : MonoBehaviour
{
    public GameObject Button;
    private const float CONST_SPACE_X = -1f;
    private const float CONST_SPACE_Y = -0.5f;

    void Start()
    {
        //Button.GetComponent<RectTransform>().localPosition = new Vector2 (-2, -2);
    }
    public void ResetPosition(float HighMessage)
    {
        Button.GetComponent<Transform>().localPosition = new Vector2(5 + CONST_SPACE_X, HighMessage/2 + CONST_SPACE_Y );
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
