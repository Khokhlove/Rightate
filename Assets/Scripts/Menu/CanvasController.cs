using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class CanvasController : MonoBehaviour
{
    public List<Canvas> canvases;
    private Canvas current;

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
        current.gameObject.SetActive(false);
        current = canvases[id];
        current.gameObject.SetActive(true);
    }
}