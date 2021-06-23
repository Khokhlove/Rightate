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

    public AnimationCurve scalePattern;
    public float speedScale;
    public Vector3 startScale;
    public Vector3 targetScale;
    public int spectrumId;
    public float r = 5;

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
        StartCoroutine(Move());
        lerp = 0;
        while (lerp < 1)
        {
            camera.orthographicSize = Mathf.Lerp(targetSize, startSize, pattern.Evaluate(lerp));
            lerp += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }
        //StartCoroutine(Rotation());
    }

    IEnumerator Move()
    {
        float angle = 0;
        while (true)
        {
            camera.transform.position = GetAngle(angle);
            angle = angle < 360 ? angle + Time.deltaTime : 0;

            yield return new WaitForEndOfFrame();
        }
    }

    Vector3 GetAngle(float angle)
    {
        Vector3 vector = new Vector3();
        vector.x = r * Mathf.Cos(angle);
        vector.y = r * Mathf.Sin(angle) + 15;
        vector.z = camera.transform.position.z;
        return vector;
    }

    //IEnumerator Rotation()
    //{
    //    Vector3 vector = new Vector3();
    //    while (true)
    //    {
    //        camera.transform.rotation = Quaternion.vec;
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

}