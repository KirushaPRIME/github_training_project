using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikerScript : ClassMessage
{
    public delegate void DoWithSendStiker(object Ob, EventArgs args);
    public static event DoWithSendStiker doWithSendStiker;

    private UInt32 Namber;

    public static int CountAnswer {  get; private set; }

    public GameObject PrefabMessage;
    public StikerManager StikerManager;
    public GameObject Content;
    
    //public List<Sprite> sprites;
    void Start()
    {
        CountAnswer = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    static int count;
    public void SendStiker()
    {
        Debug.Log(++count);
        GameObject NewMeme;
        NewMeme = Instantiate(PrefabMessage, StikerManager.Transform);
        NewMeme.GetComponent<SpriteRenderer>().sprite = StikerManager.sprites[0];
        AddMessage(NewMeme, StikerManager.sprites[0].bounds.size.x, StikerManager.sprites[0].bounds.size.y, Content);
        //doWithSendStiker(this, new EventArgs());
        CountAnswer++;
    }
    public UInt32 GetNamber() { return Namber; }
}