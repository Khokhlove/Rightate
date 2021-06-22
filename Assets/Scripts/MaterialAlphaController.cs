using System.Collections;
using UnityEngine;

public class MaterialAlphaController : MonoBehaviour
{
    public Material material;
    [Range(0,10)] public float speed = 1;

    float lerp;
    Color color;

    void Awake()
    {
        color = material.color;
        material.color = new Color(color.r, color.g, color.b, 1);
        color = material.color;
    }
    public void Hide()
    {
        StartCoroutine(_Hide());
    }
    public void Reveal()
    {
        StartCoroutine(_Reveal());
    }

    IEnumerator _Hide()
    {
        lerp = 0;
        while (lerp < 1)
        {
            material.color = Color.Lerp(color, new Color(color.r, color.g, color.b, 0), lerp);
            lerp += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator _Reveal()
    {
        lerp = 0;
        while (lerp < 1)
        {
            material.color = Color.Lerp(color, new Color(color.r, color.g, color.b, 1), lerp);
            lerp += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }    
    }

}