using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnimationTimerImage : MonoBehaviour
{
    
    public GameObject imageObject;
    [SerializeField] [Range(0, 1)]  private float animationSpeed;
    private Image image;
    private RectTransform rectTranform;
    
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



    float difference;
    
    bool reverseAppear = false;
    bool reverseScale = false;
    bool paintInit = false;
    Color32 initColor1 = new Color32();
    Color32 initColor2 = new Color32();
    int r1;
    int r2;

    TimerGame t = new TimerGame();

    public void Start()
    {
        image = imageObject.GetComponent<Image>();
        rectTranform = imageObject.GetComponent<RectTransform>();
        difference = rectTranform.localScale.x;
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
            yield return new WaitForEndOfFrame();
        }
    }

    void Scale()
    {
        if (rectTranform.localScale.x - difference >= 1)
            reverseScale = true;
        if (rectTranform.localScale.x - difference < 0)
            reverseScale = false;

        if (reverseScale == false)
            rectTranform.localScale = new Vector3(rectTranform.localScale.x + animationSpeed * Time.deltaTime, rectTranform.localScale.y + animationSpeed * Time.deltaTime);
        if (reverseScale == true)
            rectTranform.localScale = new Vector3(rectTranform.localScale.x - animationSpeed * Time.deltaTime, rectTranform.localScale.y - animationSpeed * Time.deltaTime);
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
            image.fillAmount = image.fillAmount + animationSpeed * Time.deltaTime;
        else
            image.fillAmount = image.fillAmount - animationSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        float f = Mathf.Lerp(200, 800, image.fillAmount);
        rectTranform.localRotation = Quaternion.Euler(new Vector3(0, 0, rectTranform.localRotation.eulerAngles.z + animationSpeed * f * Time.deltaTime));
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


}
