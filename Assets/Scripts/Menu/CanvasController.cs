using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public List<Canvas> canvases;
    public enum Direction {Left, Up, Right, Down};
    public Direction selecteDirection;
    public float alphaAmplifier = 2;
    List<Vector3> list = new List<Vector3>()
    {
        new Vector3(Screen.width * -1, 0),
        new Vector3(0, Screen.height * -1),
        new Vector3(Screen.width, 0),
        new Vector3(0, Screen.height),
    };
    private Canvas current;
    private Canvas previous;
    void Start()
    {
        for (int i = 0; i < canvases.Count; i++)
        {
            if (i == 0)
            {
                current = canvases[0];
                current.gameObject.SetActive(true);
            }
            else
            {
                canvases[i].gameObject.SetActive(false);
            }
        }     
    }
    public void SelectCanvas(int id)
    {
        previous = current;
        current = canvases[id]; 
        current.gameObject.SetActive(true);
        StartCoroutine(Move(() => { previous.gameObject.SetActive(false); }));   
    }

    public IEnumerator Move(UnityAction callback)
    {
        Vector3 targetPosition = list[(int)selecteDirection];
        float lerp = 0;

        RectTransform previousTransform = previous.GetComponent<RectTransform>();
        RectTransform currentTransform = current.GetComponent<RectTransform>();

        CanvasGroup previousGroup = previous.GetComponent<CanvasGroup>();
        CanvasGroup currentGroup = current.GetComponent<CanvasGroup>();

        currentTransform.anchoredPosition = list[(int)selecteDirection];
        while (lerp < 1)
        {
            previousGroup.alpha = 1 - lerp * alphaAmplifier;
            currentGroup.alpha = lerp * alphaAmplifier;
            previousTransform.anchoredPosition = Vector3.Lerp(previousTransform.anchoredPosition, targetPosition, lerp);
            currentTransform.anchoredPosition = Vector3.Lerp(currentTransform.anchoredPosition, Vector3.zero, lerp);
            lerp += Time.deltaTime;

            yield return new WaitForEndOfFrame();
        }
        callback();
    }
}