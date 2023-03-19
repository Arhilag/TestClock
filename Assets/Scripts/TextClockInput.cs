using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TextClockInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _inputText;
    private int _numWord = 1;

    public Action<Time> OnChangeText;

    public void SetTextTime(Time time)
    {
        if (time.Hour < 10)
        {
            _inputText.text = $"0{time.Hour}:";
        }
        else
        {
            _inputText.text = $"{time.Hour}:";
        }
        if (time.Minute < 10)
        {
            _inputText.text += $"0{time.Minute}:";
        }
        else
        {
            _inputText.text += $"{time.Minute}:";
        }
        if (time.Second < 10)
        {
            _inputText.text += $"0{time.Second}";
        }
        else
        {
            _inputText.text += $"{time.Second}";
        }
    }
    
    public void ChangeText(string text)
    {
        var numSymbol = _numWord;
        if (numSymbol > 6)
        {
            numSymbol = 1;
            _numWord = 1;
        }
        if (numSymbol > 4)
        {
            numSymbol++;
        }
        if (numSymbol > 2)
        {
            numSymbol++;
        }
        string firstString = _inputText.text.Substring(0,numSymbol-1);
        string secondString = _inputText.text.Substring(numSymbol);
        _inputText.text = firstString + text + secondString;
        _numWord++;
        _inputField.SetTextWithoutNotify("");
    }

    public void EndEditText(string text)
    {
        string hourString = _inputText.text.Substring(0,2);
        string minutesString = _inputText.text.Substring(3,2);
        string secondsString = _inputText.text.Substring(6,2);
        var timeData = new Time();
        timeData.Hour = int.Parse(hourString);
        timeData.Minute = int.Parse(minutesString);
        timeData.Second = int.Parse(secondsString);
        if (timeData.Hour > 23)
        {
            timeData.Hour = 23;
        }
        if (timeData.Minute > 59)
        {
            timeData.Minute = 59;
        }
        if (timeData.Second > 59)
        {
            timeData.Second = 59;
        }
        _inputText.text = $"{timeData.Hour}:{timeData.Minute}:{timeData.Second}";
        _numWord = 1;
        OnChangeText?.Invoke(timeData);
    }
}
