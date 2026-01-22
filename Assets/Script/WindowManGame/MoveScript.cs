using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Transform MainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        GetComponent<Transform>().position = new Vector2(MainCamera.GetComponent<Transform>().position.x, MainCamera.GetComponent<Transform>().position.y);
    }
}
