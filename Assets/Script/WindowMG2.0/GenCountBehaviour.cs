using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenCountBehaviour : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start()
    {
        GeneratorBehaviour.doneGEnerator += UpdateText;
        if (GateBehaviour.NamberForOpen - GeneratorBehaviour.CountDoneGane >= 0)
            text.text = (GateBehaviour.NamberForOpen - GeneratorBehaviour.CountDoneGane).ToString();
    }
    public void UpdateText(object Ob, EventArgs args)
    {
        if (GateBehaviour.NamberForOpen - GeneratorBehaviour.CountDoneGane >= 0)
            text.text = (GateBehaviour.NamberForOpen - GeneratorBehaviour.CountDoneGane).ToString();
    }
}
