using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleManager : MonoBehaviour
{
    public static float ScaleWindow{ get; private set; }
    void Update()
    {
        ScaleWindow = this.transform.localScale.y;
    }
}
