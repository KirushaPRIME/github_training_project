using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public static void Play()
    {
        Debug.Log("Click");
        SceneManager.LoadScene("Game");
    }
}
