using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmPresenter : MonoBehaviour
{
    private AlarmModel _alarmModel;
    [SerializeField] private AlarmView _alarmView;

    private IEnumerator _timer;
    
    private void Start()
    {
        _alarmModel = new AlarmModel();
        _alarmView.OnChangeTime += _alarmModel.ChangeTime;
        _alarmModel.OnChangeTimeData += OnChangeTimeData;
        _alarmView.OnChangeAngleHour += OnChangeAngleHour;
        _alarmView.OnChangeAngleMinutes += OnChangeAngleMinute;
        _alarmView.OnChangeAngleSeconds += OnChangeAngleSecond;
        _alarmView.OnClickComplete += OnClickComplete;
        _timer = Timer();
    }

    private void OnDestroy()
    {
        _alarmView.OnChangeTime -= _alarmModel.ChangeTime;
        _alarmModel.OnChangeTimeData -= OnChangeTimeData;
        _alarmView.OnChangeAngleHour -= OnChangeAngleHour;
        _alarmView.OnChangeAngleMinutes -= OnChangeAngleMinute;
        _alarmView.OnChangeAngleSeconds -= OnChangeAngleSecond;
        _alarmView.OnClickComplete -= OnClickComplete;
    }

    private void OnClickComplete()
    {
        if (_alarmModel.AlarmComplete)
        {
            StopCoroutine(_timer);
        }
        _alarmModel.SetComplete();
        StartCoroutine(_timer);
    }

    private IEnumerator Timer()
    {
        while (_alarmModel.AlarmTime.Hour != ClockPresenter.Instance.GetTimeData().Hour ||
               _alarmModel.AlarmTime.Minute != ClockPresenter.Instance.GetTimeData().Minute ||
               _alarmModel.AlarmTime.Second != ClockPresenter.Instance.GetTimeData().Second)
        {
            yield return new WaitForSeconds(1);
        }
        _alarmView.AlarmPopUp();
    }

    private void OnChangeAngleHour(float angle)
    {
        StopCoroutine(_timer);
        Time time = _alarmModel.AlarmTime;
        time.Hour = (int)(angle / (360f / 12f));
        if (time.Hour < 0)
        {
            time.Hour += 12;
        }
        _alarmModel.ChangeTime(time);
    }

    private void OnChangeAngleMinute(float angle)
    {
        StopCoroutine(_timer);
        Time time = _alarmModel.AlarmTime;
        time.Minute = (int)(angle / (360f / 60f));
        if (time.Minute < 0)
        {
            time.Minute += 60;
        }
        _alarmModel.ChangeTime(time);
    }

    private void OnChangeAngleSecond(float angle)
    {
        StopCoroutine(_timer);
        Time time = _alarmModel.AlarmTime;
        time.Second = (int)(angle / (360f / 60f));
        if (time.Second < 0)
        {
            time.Second += 60;
        }
        _alarmModel.ChangeTime(time);
    }

    private void OnChangeTimeData(Time time)
    {
        StopCoroutine(_timer);
        _alarmView.UpdateUITime(time);
    }
}
