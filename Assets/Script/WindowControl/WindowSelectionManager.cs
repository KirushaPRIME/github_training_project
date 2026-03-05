using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class WindowSelectionManager : MonoBehaviour
{
    private float WidthMenu;
    private float WidthPreview;
    private float HeigthPreview;
    private float Space;
    private int CountPreview;

    private float[] PreviewPositions;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void CreateMenu(UnityEngine.UI.Image[] Previews, float WidthMenu, Transform Parent, float Space = 1, float AspectRatio = 16 / 9, int CountLevel = 1)
    {
        this.WidthMenu = WidthMenu;
        this.Space = Space;
        CountPreview = Previews.Length;
        WidthPreview = (WidthMenu - (CountPreview + 1) * Space) / CountPreview;
        HeigthPreview = WidthPreview * 1 / AspectRatio;

        float JustVar;

        CalculatePosition();

        int Count = 0;
        foreach (var PI in Previews)
        {
            /*
             * Иницилизируем два объекта
             * 1. Preview - 
             *      В качестве его ребёнка будет храниться объект с изображением, а само превью будет для него маской
             * 2. ImageOb -
             *      Дочерний объект Preview, хранит в себе изображение для превью
             */
            GameObject Preview = new GameObject();
            Preview.name = "PreviewFor" + PI.name;
            Preview.GetComponent<Transform>().SetParent(Parent);
            Preview.AddComponent<UnityEngine.UI.Mask>();
            Preview.GetComponent<Transform>().localPosition = new Vector2(PreviewPositions[Count], 0);

            GameObject ImageOb = new GameObject();
            ImageOb.name = "PreviewImage";
            ImageOb.GetComponent<Transform>().
                SetParent(Preview.GetComponent<Transform>());
            ImageOb.AddComponent<UnityEngine.UI.Image>();
            ImageOb.GetComponent<UnityEngine.UI.Image>().sprite = PI.sprite;
            ImageOb.GetComponent<Transform>().localPosition = Vector3.zero;

            /*
             * Находим коэфициент на который нужно умножить размер изображения и он вошёл в окно
             */
            if (PI.sprite.bounds.size.x / PI.sprite.bounds.size.y >= AspectRatio)
                JustVar = HeigthPreview / PI.sprite.bounds.size.y;
            else
                JustVar = WidthPreview / PI.sprite.bounds.size.x;

            ImageOb.GetComponent<RectTransform>().sizeDelta =
                new Vector2(
                    JustVar * PI.sprite.bounds.size.x, 
                    JustVar * PI.sprite.bounds.size.y
                );
            Preview.GetComponent<RectTransform>().sizeDelta = new Vector2(WidthPreview, HeigthPreview);
        }
    }
    private void CalculatePosition()
    {
        PreviewPositions = new float[CountPreview];
        PreviewPositions[0] = -WidthMenu / 2 + Space + WidthPreview / 2; // Позиция первого элемента
        for (int i = 1; i < PreviewPositions.Length; i++)
            PreviewPositions[i] = PreviewPositions[i - 1] + (WidthMenu + Space);
    }
}
