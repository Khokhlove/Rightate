using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNowButtonScaler : MonoBehaviour
{
    public float amplifier = 0.5f;
    public Vector3 targetScale = new Vector3(1.1f, 1.1f, 1.1f);

    Vector3 startScale;
    // Update is called once per frame
    private void Start()
    {
        startScale = transform.localScale;
        StartCoroutine(Scale(true));
    }

    IEnumerator Scale(bool forward)
    {
        float timer = forward ? 0 : 1;

        if (forward)
        {
            while (timer <= 1f)
            {
                transform.localScale = Vector3.Lerp(startScale, targetScale, timer);
                timer += Time.deltaTime * amplifier;
                yield return new WaitForEndOfFrame();
            }

            StartCoroutine(Scale(false));
        } else
        {
            while (timer >= 0f)
            {
                transform.localScale = Vector3.Lerp(startScale, targetScale, timer);
                timer -= Time.deltaTime * amplifier;
                yield return new WaitForEndOfFrame();
            }

            StartCoroutine(Scale(true));
        }
    }
}
