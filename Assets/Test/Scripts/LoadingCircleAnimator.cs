using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoadingCircleAnimator : MonoBehaviour
{
    [Header("Привязка элементов:")]
    [Tooltip("Изображения для поялвения, масштабирования и покраски:")]
    public Image image;
    [Tooltip("RectTransform для осуществленрия поворота:")]
    public RectTransform rt;
    [Tooltip("Привязка TextBox для прогрузки полоски:")]
    public Text timerText;
    [Space]

    [Header("Включение и отключение функций:")]
    public bool appear = false;
    public bool appearTime = false;
    public bool rotation = false;
    public bool scale = false;
    public bool paint = false;

    [Header("Массив цветов для перехода:")]
    public Color32[] col = new Color32[]
    {
        new Color32(125, 0, 255, 255),
        new Color32(0, 255, 255, 255),
        new Color32(255, 255, 0, 255),
        new Color32(255, 0, 0, 255)
    };

    [Header("Регулировщик скорости:")]
    [Range(0, 1)]
    public float speed;


    float difference;
    
    bool reverseAppear = false;
    bool reverseScale = false;
    bool paintInit = false;
    Color32 initColor1 = new Color32();
    Color32 initColor2 = new Color32();
    int r1;
    int r2;

    TimerGame t = new TimerGame();

    void Start()
    {
        difference = rt.localScale.x;
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        while (this.enabled == true)
        {
            if(appear) Appear();
            if (scale) Scale();
            if (rotation) Rotate();
            if (paint) Paint();
            if (appearTime) AppearTime();
            yield return new WaitForEndOfFrame();
        }
    }

    void Scale()
    {
        if (rt.localScale.x - difference >= 1)
            reverseScale = true;
        if (rt.localScale.x - difference < 0)
            reverseScale = false;

        if (reverseScale == false)
            rt.localScale = new Vector3(rt.localScale.x + speed * Time.deltaTime, rt.localScale.y + speed * Time.deltaTime);
        if (reverseScale == true)
            rt.localScale = new Vector3(rt.localScale.x - speed * Time.deltaTime, rt.localScale.y - speed * Time.deltaTime);
    }
    void Appear()
    {
        if (image.fillAmount >= 1)
        {
            reverseAppear = true;
            image.fillClockwise = false;
        }
        if (image.fillAmount <= 0)
        {
            reverseAppear = false;
            image.fillClockwise = true;
        }

        if (reverseAppear == false)
            image.fillAmount = image.fillAmount + speed * Time.deltaTime;
        else
            image.fillAmount = image.fillAmount - speed * Time.deltaTime;
    }

    void Rotate()
    {
        float f = Mathf.Lerp(200, 800, image.fillAmount);
        rt.localRotation = Quaternion.Euler(new Vector3(0, 0, rt.localRotation.eulerAngles.z + speed * f * Time.deltaTime));
    }

    void Paint()
    {
        int i = col.Length - 1;

        if (paintInit == false)
        {
            r1 = UnityEngine.Random.Range(0, i);
            r2 = UnityEngine.Random.Range(0, i);

            while (r1 == r2)
                r2 = UnityEngine.Random.Range(0, i);

            initColor1 = col[r1];
            initColor2 = col[r2];
            paintInit = true;
        }
        image.color = Color32.Lerp(initColor1, initColor2, image.fillAmount);

        if (image.fillAmount >= 1)
        {
            r1 = UnityEngine.Random.Range(0, i);
            while (r1 == r2)
                r1 = UnityEngine.Random.Range(0, i);
            initColor1 = col[r1];
        }
        if (image.fillAmount <= 0)
        {
            r2 = UnityEngine.Random.Range(0, i);
            while (r1 == r2)
                r2 = UnityEngine.Random.Range(0, i);
            initColor2 = col[r2];
        }
    }
    void AppearTime()
    {
        float f;
        Text t = timerText;

        if (t != null)
        {
            float.TryParse(t.text, out f);
            image.fillAmount = f / 60;
        }
    }

}
