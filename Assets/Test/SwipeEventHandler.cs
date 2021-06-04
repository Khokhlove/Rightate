using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SwipeEventHandler : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public UnityEvent up;
    public UnityEvent down;
    public UnityEvent left;
    public UnityEvent right;
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0) right.Invoke();
            else left.Invoke();
        }
        else
        {
            if (eventData.delta.y > 0) up.Invoke();
            else down.Invoke();
        }
    }

    public void OnDrag(PointerEventData eventData)

    {

    }
}