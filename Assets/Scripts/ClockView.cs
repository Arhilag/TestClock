using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockView : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private ClockAnimator _clockAnimator;
    [SerializeField] private Button _alarmButton;
    [SerializeField] private GameObject _alarmContainer;

    private void Awake()
    {
        _alarmButton.onClick.AddListener(OpenAlarm);
    }

    private void OnDestroy()
    {
        _alarmButton.onClick.RemoveListener(OpenAlarm);
    }

    public void ChangeTime(Time time)
    {
        _timeText.text = $"{time.Hour}:{time.Minute}:{time.Second}";
        _clockAnimator.UpdateTime(time);
    }

    private void OpenAlarm()
    {
        _alarmContainer.SetActive(true);
    }
}
