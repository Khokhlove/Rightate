using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SwipeEventHandler : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public UnityEvent up;
    public UnityEvent down;
    public UnityEvent left;
    public UnityEvent right;

    public Vector2 startDelta;
    public Vector2 targetDelta;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startDelta = eventData.pressPosition;
        //if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        //{
        //    if (eventData.delta.x > 0) right.Invoke();
        //    else left.Invoke();
        //}
        //else
        //{
        //    if (eventData.delta.y > 0) up.Invoke();
        //    else down.Invoke();
        //}
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        targetDelta = eventData.position;
        if (Mathf.Abs((startDelta.x - eventData.position.x)) > Mathf.Abs((startDelta.y - eventData.position.y)))
        {
            if ((startDelta.x - eventData.position.x) > 0) left.Invoke();
            else right.Invoke();
        }
        else
        {
            if ((startDelta.y - eventData.position.y) > 0) down.Invoke();
            else up.Invoke();
        }
    }
}