using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MemeManager : ClassMessage
{
    public List<Sprite> spriteList;
    public List<Sprite> spriteListForWork;
    public GameObject PrefabMeme;

    public int MaxCountMissedMessage;

    int LastCountAnswer;
    int CountMissedMessage;

    public static float MiddlePause;
    private float PostTime = 0;

    private AudioSource audioSource;

    private void Awake()
    {

    }

    void Start()
    {
        MemeManager.MiddlePause = 30;
        MaxCountMissedMessage = 3;

        // Настройка сложности
        if (Scenes.Level > 2)
            MiddlePause = 25;
        if (Scenes.Level > 3)
            MiddlePause = 15;
        if (Scenes.Level > 4)
            MiddlePause = 12;
         

        LastCountAnswer = 0;
        CountMissedMessage = 0;
        audioSource = GetComponent<AudioSource>();
        PostTime = Time.time + Random.Range(MiddlePause / 2, MiddlePause * 1.5f);
    }

    void Update()
    {
        if (PostTime < Time.time)
        {
            PostTime = Time.time + Random.Range(MiddlePause / 2, MiddlePause * 1.5f);
            AddMeme(Random.Range(0, spriteList.Count - 1));
        }
    }

    public bool AddMeme(int Index)
    {
        if (Index > spriteList.Count || Index < 0)
        {
            return false;
        }
        
        GameObject NewMeme;
        NewMeme = Instantiate(PrefabMeme,GetComponent<Transform>());
        NewMeme.GetComponent<Image>().sprite = spriteList[(int)Index];
        //NewMeme.GetComponent<PositionButtonControl>().ResetPosition(spriteList[(int)Index].bounds.size.y);
        AddMessage(NewMeme.GetComponent<RectTransform>(), spriteList[(int)Index].bounds.size.x, spriteList[(int)Index].bounds.size.y, GetComponent<RectTransform>());
        audioSource.Play();
        CheakAnswer();
        return true;
    }

    void CheakAnswer()
    {
        if (LastCountAnswer < StikerScript.CountAnswer + 1)
        {
            LastCountAnswer = StikerScript.CountAnswer;
        } else
        {
            CountMissedMessage++;
        }
        if (CountMissedMessage > MaxCountMissedMessage)
        {
            Scenes.GameOver("Игнорировал посты Олега");
        }
    }
}
