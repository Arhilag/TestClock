using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnimator : MonoBehaviour
{
    [SerializeField] private Transform _hourTransform;
    [SerializeField] private Transform _minutesTransform;
    [SerializeField] private Transform _secondsTransform;
    private float hoursToDegrees = 360f / 12f;
    private float minutesToDegrees = 360f / 60f;
    private float secondsToDegrees = 360f / 60f;

    public void UpdateTime(Time time)
    {
        _hourTransform.localRotation = Quaternion.Euler(0f,0f,time.Hour * -hoursToDegrees);
        _minutesTransform.localRotation = Quaternion.Euler(0f,0f,time.Minute * -minutesToDegrees);
        _secondsTransform.localRotation = Quaternion.Euler(0f,0f,time.Second * -secondsToDegrees);
    }
}
