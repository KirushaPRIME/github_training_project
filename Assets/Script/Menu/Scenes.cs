using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public const int MaxLevel = 5;
    public static int Level { 
        get {
            if (!PlayerPrefs.HasKey("Level"))
            {
                PlayerPrefs.SetInt("Level", 1);
            }
            return PlayerPrefs.GetInt("Level");
        }
        private set
        {
            PlayerPrefs.SetInt("Level", value);
        }
    }
    private void Start()
    {
        //PlayerPrefs.SetInt("Level", 1);
    }

    public static void GameOver(string Reason)
    {
        BanReasonBehaviour.reason = Reason;
        SceneManager.LoadScene("GameOverScene");
    }

    public static void CompliteNight()
    {
        if (MaxLevel > Level) Level++;
        SceneManager.LoadScene("CompliteNight");
    }

    public static void Play()
    {
        Debug.Log("Level: " + Level);
        SceneManager.LoadScene("Game");
    }

    public static void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
