using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.PlayerLoop.PreUpdate;

/*

Основная работа незапрета, можно узнать активен ли нужный сервис через NeedServiceIsInstate

*/
public class ControlNeZapreta : MonoBehaviour
{
    public bool IsActive;
    public InternetManager internetManager;
    public bool HUYNA = false;
    public short WorkingService;
    public TextMeshProUGUI inputFiled;
    private KeyCode[] keyCodes = {KeyCode.Keypad0,
        KeyCode.Keypad1,
        KeyCode.Keypad2,
        KeyCode.Keypad3,
        KeyCode.Keypad4,
        KeyCode.Keypad5,
        KeyCode.Keypad6,
        KeyCode.Keypad7,
        KeyCode.Keypad8,
        KeyCode.Keypad9 };
    private short MaxWaitingTime = 4;
    private short MinWaitingTime = 2;
    private float TimeStop = 0;
    private short LengthInput = 0;
    public short NamberInstalService = -1;
    public const short CountService = 9;
    private string StrInput = "";
    private short NamberMenu = 0;
    private short NamberIterartionTest = 1;
    private bool IsStartTest;
    private bool IsSwithced;
    private bool ServiceIsInstale;
    public short NamberNeedService = -1;
    public bool NeedServiceIsInstate => NamberNeedService == NamberInstalService;



    private string Menu0 = " ----- NeZapret V999.absolut ----- \n" +
            "--------------------------------------------\n" +
            "Choose an action: \n" +
            "1. Instal Service \n" +
            "2. Remuve Service \n" +
            "3. Run Tests \n" +
        "\n" +
        "Enter Namber: ";
    private string Menu1 = "Choose an Service \n" +
        "1. general (Alt1).what? \n" +
        "2. general (Alt2).what? \n" +
        "3. general (Alt3).what? \n" +
        "4. general (Alt4).what? \n" +
        "5. general (Alt5).what? \n" +
        "6. general (Alt6).what? \n" +
        "7. general (Alt7).what? \n" +
        "8. general (Alt8).what? \n" +
        "9. general (Alt9).what? \n" +
        "\n" +
        "Enter Namber: ";
    private string Menu2 = "All service are stopped!\n" +
        "\n" +
        "Press Enter to continue\n";
    private string Menu3;

    void Start()
    {
        inputFiled.text = Menu0;
    }

    void Update()
    {
        if (TimeStop > Time.time) goto EndUpdate;
        //Debug.Log(TimeStop);
        if (IsStartTest)
        {
            Test();
            goto EndUpdate;
        }
        if (IsSwithced)
        {
            switch (NamberMenu)
            {
                case 0: inputFiled.text = Menu0; break;
                case 1: inputFiled.text = Menu1; break;
                case 2: inputFiled.text = Menu2; break;
                case 3: inputFiled.text = Menu3; break;
            }
            IsSwithced = false;
        }
        if (LengthInput < 100)
        {
            for (int i = 0; i < keyCodes.Length; i++)
            {
                if (Input.GetKeyUp(keyCodes[i]))
                {
                    inputFiled.text += i;
                    StrInput += i;
                    LengthInput++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            LengthInput = 0;
            switch (NamberMenu)
            {
                case 0:
                    SwitchOptions();
                    break;
                case 1:
                    InstaleService();
                    break;
                case 2:
                    RemuveService();
                    break;
                case 3:
                    SwitchMenu(0);
                    break;
            }
            //Debug.Log(NamberMenu);
            StrInput = "";
        }
        if (Input.GetKeyUp(KeyCode.Backspace) && LengthInput > 0)
        {
            inputFiled.text = inputFiled.text.Remove(inputFiled.text.Length - 1);
            LengthInput--;
        }
    //InternetManager.SetInternetStatus(HUYNA);
    EndUpdate:;
    }
    private void SwitchOptions()
    {
        switch (StrInput)
        {
            case "1":
                SwitchMenu(1);
                break;
            case "2":
                NamberInstalService = -1;
                SwitchMenu(2);
                DoPause(MinWaitingTime, MaxWaitingTime);
                break;
            case "3":
                Test();
                IsStartTest = true;
                break;
            default:
                SwitchMenu(0);
                break;
        }
    }
    private void InstaleService()
    {
        if (!ServiceIsInstale)
            switch (StrInput)
            {
                case "1": NamberInstalService = 1; goto IsInstale;
                case "2": NamberInstalService = 2; goto IsInstale;
                case "3": NamberInstalService = 3; goto IsInstale;
                case "4": NamberInstalService = 4; goto IsInstale;
                case "5": NamberInstalService = 5; goto IsInstale;
                case "6": NamberInstalService = 6; goto IsInstale;
                case "7": NamberInstalService = 7; goto IsInstale;
                case "8": NamberInstalService = 8; goto IsInstale;
                case "9": NamberInstalService = 9; goto IsInstale;
            }
        SwitchMenu(0);
        return;
    IsInstale:
        internetManager.SetInternetStatus(NeedServiceIsInstate);
        ServiceIsInstale = true;
        DoPause(MinWaitingTime, MaxWaitingTime);
        SwitchMenu(0);
    }
    private void RemuveService()
    {
        NamberInstalService = -1;
        ServiceIsInstale = false;
        SwitchMenu(0);
    }
    private void DoPause(float MinWaitingTime, float MaxWaitingTime)
    {
        inputFiled.text += "\nPlease wait...\n";
        TimeStop = Time.time + UnityEngine.Random.Range(MinWaitingTime * 10, MaxWaitingTime * 10) / 10;
    }
    private void Test()
    {
        //Debug.Log("TEST");
        inputFiled.text = "Testing the service (Alt" + NamberIterartionTest +
            ").what?";
        if (NamberIterartionTest == CountService)
        {
            IsStartTest = false;
            Menu3 = "Best Service is (Alt" + NamberNeedService + ").what\n" +
                "Press Enter to continue\n";
            NamberIterartionTest = 0;
            SwitchMenu(3);
        }
        NamberIterartionTest++;
        DoPause(MinWaitingTime, MaxWaitingTime);
    }
    private void SwitchMenu(short Namber)
    {
        NamberMenu = Namber;
        IsSwithced = true;
    }
}
