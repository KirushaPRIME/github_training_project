using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : Scenes
{
    public void _ResetLevel()
    {
        Level = 1;
        SceneManager.LoadScene("Menu");
    }
}
