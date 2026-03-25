using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Surv")
            Scenes.CompliteNight();
    }
}
