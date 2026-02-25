using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetManager : MonoBehaviour
{
    private bool IsConnect = true;
    private float TimeDisconect;
    public ControlNeZapreta ControlNeZapreta;
    public ACrutchForInternet[] ACrutchForInternetArray;
    public bool DisconectThis = false;

    void Start()
    {
        Connection();
    }
    void Update()
    { 
        if (DisconectThis)
        {
            Disconect();
            DisconectThis = false;
        }
    }

    private void Disconect()
    {
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
