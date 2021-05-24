using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColorShifter : MonoBehaviour
{
    public Material mat;
    public List<Color> colors;

    [Range(0.1f, 1)]
    public float amplifier = 0.1f;

    int currColorId = 1;
    float time = 0;

    private void Start()
    {
        Color start = colors[currColorId - 1];
        Color target= colors[currColorId];
        StartCoroutine(ChangeColor(start, target));
    }

    void Update()
    {
        time += Time.deltaTime * amplifier;
    }

    IEnumerator ChangeColor(Color start, Color target)
    {
        while (time < 1)
        {
            mat.color = Color.Lerp(start, target, time);

            yield return new WaitForEndOfFrame();
        }

        Color tempStart;
        Color tempTarget;

        if (currColorId + 1 <= colors.Count - 1)
        {
            tempStart = colors[currColorId];
            tempTarget = colors[currColorId + 1];
            currColorId += 1;
        }
        else {
            tempStart = colors[currColorId];
            tempTarget = colors[0];
            currColorId = 0;
        }

        time = 0;

        StartCoroutine(ChangeColor(tempStart, tempTarget));
    }
}
