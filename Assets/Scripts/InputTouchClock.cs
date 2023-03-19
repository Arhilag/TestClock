using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTouchClock : MonoBehaviour
{
    [SerializeField] private InputTouch _touchHour;
    [SerializeField] private InputTouch _touchMinutes;
    [SerializeField] private InputTouch _touchSeconds;

    public InputTouch TouchHour => _touchHour;
    public InputTouch TouchMinutes => _touchMinutes;
    public InputTouch TouchSeconds => _touchSeconds;
}
