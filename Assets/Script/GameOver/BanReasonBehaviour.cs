using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BanReasonBehaviour : MonoBehaviour
{
    public TextMeshProUGUI preview;

    static string str;

    public static string reason
    {
        get
        {
            return str;
        }
        set
        {
            str = "¬€ ¡€À» «¿¡¿Õ≈Õ€. œ–»◊»Õ¿:\n" + value;
        }
    }

    void Start()
    {
        preview.text = str;
    }
}
