using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;

public class InputTouch : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Action<float> OnChangeAngle;
    private Vector2 _center;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _center = Camera.main.WorldToScreenPoint(transform.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var angle = Vector2.Angle(Vector2.down, _center-eventData.position);
        if (eventData.position.x - _center.x < 0)
        {
            angle *= -1;
        }
        OnChangeAngle?.Invoke(angle);
    }
}
