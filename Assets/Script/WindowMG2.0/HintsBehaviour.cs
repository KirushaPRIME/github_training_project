using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintsBehaviour : MonoBehaviour
{
    public enum TypeMessage { BaseIteraction, SpecialMessage}

    List<string> Hints;
    string BaseIteractionMessage;
    TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        
        Hints = new List<string>();
    }
    private void Start()
    {
        BaseIteractionMessage = "Click " + KeyManager.Interaction.ToString() + " to interact";
    }
    public void UpdateHint(bool Add, TypeMessage newHint)
    {
        switch (newHint)
        {
            case TypeMessage.BaseIteraction:
                if (Add)
                    Hints.Add(BaseIteractionMessage);
                else
                    Hints.Remove(BaseIteractionMessage);
                    break;
        }
        _textMeshPro.text = "";
        foreach (string hint in Hints)
            _textMeshPro.text += hint;
    }
}
