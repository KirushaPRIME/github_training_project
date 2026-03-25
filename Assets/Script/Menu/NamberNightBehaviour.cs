using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NamberNightBehaviour : MonoBehaviour
{
    public TextMeshProUGUI NamberNight;
    void Start()
    {
        NamberNight.text = "Ночь: " + Scenes.Level;
    }
}
