using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsBehaviour : MonoBehaviour
{
    TextMeshPro _textMeshPro;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }
    public void UpdateHint(string newHint)
    {
        _textMeshPro.text = newHint;
    }
}
