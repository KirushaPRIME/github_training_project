using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorBarScript : MonoBehaviour
{
    public GeneratorScript Generator;
    void Start()
    {
        
    }
    void Update()
    {
        GetComponent<Image>().fillAmount = Generator.GetProgress()/ God.NEED_PROGRESS_FOR_GENERATOR;
    }
}
