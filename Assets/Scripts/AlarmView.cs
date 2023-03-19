using System;
using UnityEngine;
using UnityEngine.UI;

public class AlarmView : MonoBehaviour
{
    [SerializeField] private TextClockInput _textClockInput;
    [SerializeField] private ClockAnimator _clockAnimator;
    [SerializeField] private InputTouchClock _inputTouchClock;
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _completeButton;
    [SerializeField] private GameObject _alarmContainer;
    [SerializeField] private GameObject _alarmPopup;

    public Action<Time> OnChangeTime;
    public Action<float> OnChangeAngleHour;
    public Action<float> OnChangeAngleMinutes;
    public Action<float> OnChangeAngleSeconds;
    public Action OnClickComplete;

    private void Awake()
    {
        _textClockInput.OnChangeText += ChangeTime;
        _inputTouchClock.TouchHour.OnChangeAngle += ChangeAngleHour;
        _inputTouchClock.TouchMinutes.OnChangeAngle += ChangeAngleMinutes;
        _inputTouchClock.TouchSeconds.OnChangeAngle += ChangeAngleSeconds;
        _exitButton.onClick.AddListener(ExitWindowAlarm);
        _completeButton.onClick.AddListener(CompleteAlarm);
    }

    private void OnDestroy()
    {
        _textClockInput.OnChangeText -= ChangeTime;
        _inputTouchClock.TouchHour.OnChangeAngle -= ChangeAngleHour;
        _inputTouchClock.TouchMinutes.OnChangeAngle -= ChangeAngleMinutes;
        _inputTouchClock.TouchSeconds.OnChangeAngle -= ChangeAngleSeconds;
        _exitButton.onClick.RemoveListener(ExitWindowAlarm);
        _completeButton.onClick.RemoveListener(CompleteAlarm);
    }

    private void ChangeAngleHour(float value)
    {
        OnChangeAngleHour?.Invoke(value);
    }

    private void ChangeAngleMinutes(float value)
    {
        OnChangeAngleMinutes?.Invoke(value);
    }

    private void ChangeAngleSeconds(float value)
    {
        OnChangeAngleSeconds?.Invoke(value);
    }

    private void ChangeTime(Time time)
    {
        OnChangeTime?.Invoke(time);
    }

    public void UpdateUITime(Time time)
    {
        _clockAnimator.UpdateTime(time);
        _textClockInput.SetTextTime(time);
    }

    private void ExitWindowAlarm()
    {
        _alarmContainer.SetActive(false);
    }
    
    private void CompleteAlarm()
    {
        OnClickComplete?.Invoke();
        _alarmContainer.SetActive(false);
    }

    public void AlarmPopUp()
    {
        _alarmPopup.SetActive(true);
    }
}
