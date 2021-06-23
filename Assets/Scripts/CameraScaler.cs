using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CameraScaler : MonoBehaviour
{
    float lerp = 0;
    public Camera camera;
    float startSize;

    public AnimationCurve pattern;
    public float targetSize = 7.5f;
    public float speed = 1;

    void Start()
    {
        startSize = camera.orthographicSize;
        camera.orthographicSize = targetSize;
    }

    public void Scale()
    {
        StartCoroutine(_Scale());
    }

    IEnumerator _Scale()
    {
        lerp = 0;
        while (lerp < 1)
        {
            camera.orthographicSize = Mathf.Lerp(targetSize, startSize, pattern.Evaluate(lerp));
            lerp += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
    }

}