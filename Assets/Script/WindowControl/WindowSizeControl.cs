using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowSizeControl : MonoBehaviour
{
    public Camera camera;
    void Start()
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(
            camera.orthographicSize * 2 * camera.aspect,
            camera.orthographicSize * 2
            );
    }
    void Update()
    {
        
    }
}
