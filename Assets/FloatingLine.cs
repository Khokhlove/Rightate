using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingLine : MonoBehaviour
{
    public GameObject parent;
    public GameObject line;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scroll());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Scroll()
    {
        float parentWidth = parent.GetComponent<RectTransform>().sizeDelta.x;

        RectTransform lt = line.GetComponent<RectTransform>();
        lt.anchoredPosition3D = new Vector3(parentWidth, 0);

        while(lt.anchoredPosition3D.x + lt.sizeDelta.x > 0)
        {
            lt.anchoredPosition3D -= new Vector3(Time.deltaTime, 0) * speed;
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(Scroll());
    }
}
