using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetManager : MonoBehaviour
{
    private bool IsConnect = true;
    private float TimeDisconect;
    private float DisconectFrequency;
    public ControlNeZapreta ControlNeZapreta;
    public ACrutchForInternet[] ACrutchForInternetArray;
    public bool DisconectThis = false;

    private void Awake()
    {
        DisconectFrequency = 200;
        switch (Scenes.Level)
        {
            case 1:
                break;
            case 2:
                DisconectFrequency = 200;
                break;
            case 3:
                DisconectFrequency = 130;
                break;
            case 4:
                DisconectFrequency = 100;
                break;
            case 5:
                DisconectFrequency = 80;
                break;
        }
    }

    void Start()
    {
        if (DisconectFrequency == 0)
            GetComponent<InternetManager>().enabled = false;
        Connection();
        TimeDisconect = Time.time + UnityEngine.Random.Range(DisconectFrequency / 2, DisconectFrequency * 2);
    }

    void Update()
    { 

        if (TimeDisconect < Time.time)
        {
            TimeDisconect = Time.time + UnityEngine.Random.Range(DisconectFrequency / 2, DisconectFrequency * 2);
            DisconectThis = true;
            
        }



        if (DisconectThis)
        {
            Disconect();
            DisconectThis = false;
        }
    }

    private void Disconect()
    {
        Debug.Log("Disconect");
        ControlNeZapreta.NamberNeedService = Convert.ToInt16(UnityEngine.Random.Range(1, ControlNeZapreta.CountService));
        SetInternetStatus(false);

    }


    public void SetInternetStatus(bool IsConnect)
    {
        if (IsConnect)
        {
            Connection();
        }
        else
        {
            Disconnection();
        }
    }
    private void Connection()
    {
        foreach (var ob in ACrutchForInternetArray)
        {
            ob.DoWhenConnection();
        }
    }
    private void Disconnection()
    {
        foreach (var ob in ACrutchForInternetArray)
        {
            ob.DoWhenDisconnection();
        }
    }
}
