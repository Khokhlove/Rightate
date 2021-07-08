using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class EqualizerColumns : MonoBehaviour
{
    [SerializeField] private List<RectTransform> columns;
    [SerializeField] private FrequencyMover cubes;
    public float amplyfier;
    public int offset;
    [Range(0, 1)] public float speed;
    
    void Start()
    {

    }

    void Update()
    {
        if (cubes.spectrum.Count > 0)
            for (int i = 0; i < columns.Count; i++)
            {
                Vector2 vect = columns[i].anchoredPosition;
                columns[i].anchoredPosition = Vector2.Lerp(new Vector2(vect.x, vect.y), new Vector2(vect.x, cubes.spectrum[offset + i] * amplyfier), speed) ;
            }
    }
}