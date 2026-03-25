using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MemeManager : ClassMessage
{
    public List<Sprite> spriteList;
    public List<Sprite> spriteListForWork;
    public GameObject PrefabMeme;

    public int MaxCountMissedMessage;

    int LastCountAnswer;
    int CountMissedMessage;

    public static float Frequency;
    private float PostTime = 0;

    private AudioSource audioSource;

    private void Awake()
    {

    }

    void Start()
    {
        MemeManager.Frequency = 30;
        MaxCountMissedMessage = 3;

        if (Scenes.Level > 2)
                Frequency = 20;
        if (Scenes.Level > 3)
                Frequency = 15;
        if (Scenes.Level > 4)
                Frequency = 12;
         

        LastCountAnswer = 0;
        CountMissedMessage = 0;
        audioSource = GetComponent<AudioSource>();
        PostTime = Time.time + Random.Range(Frequency / 2, Frequency * 1.5f);
    }

    void Update()
    {
        if (PostTime < Time.time)
        {
            PostTime = Time.time + Random.Range(Frequency / 2, Frequency*1.5f);
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
        NewMeme.GetComponent<SpriteRenderer>().sprite = spriteList[(int)Index];
        //NewMeme.GetComponent<PositionButtonControl>().ResetPosition(spriteList[(int)Index].bounds.size.y);
        AddMessage(NewMeme, spriteList[(int)Index].bounds.size.x, spriteList[(int)Index].bounds.size.y, GetComponent<Transform>().gameObject);
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
