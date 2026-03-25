using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class СongratulationBehaviour : MonoBehaviour
{
    public TextMeshProUGUI preview;
    private string str;
    void Start()
    {
        str = "Отличная работа!\nВы прошли " + (Scenes.Level - 1) + "-ю ночь!";
        preview.text = str;
    }
}
