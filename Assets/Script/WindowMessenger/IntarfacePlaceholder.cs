using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class IntarfacePlaceholder : MonoBehaviour
    {
        [SerializeField] public RectTransform MessengerWindow;
        [SerializeField] public RectTransform StikerPackTable;
        [SerializeField] public RectTransform ChatTable;
        [SerializeField] private float StikerPackTableWidth;
        [SerializeField] private float StikerPackTablePosX;


        void Awake()
        {
            float SizeY, SizeX;
            StikerPackTable.sizeDelta = new Vector2(StikerPackTableWidth, MessengerWindow.sizeDelta.y);
            StikerPackTable.anchoredPosition = new Vector2(-StikerPackTableWidth/2, 0);
            SizeY = -MessengerWindow.sizeDelta.x - StikerPackTableWidth - 5;
            ChatTable.anchoredPosition = new Vector2(-StikerPackTableWidth + SizeY / 2 - 1, 0);
            ChatTable.sizeDelta = new Vector2(-SizeY, MessengerWindow.sizeDelta.y - 1);
            Debug.Log(MessengerWindow.sizeDelta.y - 1);
            
            //StikerPackTable.offsetMin = new Vector2(-3, MessengerWindow.sizeDelta.y);
        }
    }
}
