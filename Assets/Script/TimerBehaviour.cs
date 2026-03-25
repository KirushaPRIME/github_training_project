using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = ((int)(Time.time / 60)).ToString() + ":" + ((int)(Time.time % 60)).ToString();
    }
}
