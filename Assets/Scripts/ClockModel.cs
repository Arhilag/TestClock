using System;
using System.Threading.Tasks;
using UnityEngine;

public class ClockModel
{
    private DateTime _netTime;
    private Time _time;
    public Time Time => _time;
    
    public Action<Time> OnChangeTime;

    public ClockModel()
    {
        WorkClock();
    }

    public void CorrectTime(DateTime correctTime)
    {
        _netTime = correctTime;
        ChangeTime();
    }

    private void ChangeTime()
    {
        _time.Hour = _netTime.Hour;
        _time.Minute = _netTime.Minute;
        _time.Second = _netTime.Second;
    }

    private async void WorkClock()
    {
        while (Application.isPlaying)
        {
            await Task.Delay(1000);
        
            _time.Second++;
            if (_time.Second >= 60)
            {
                _time.Minute++;
                _time.Second -= 60;
            }
            if (_time.Minute >= 60)
            {
                _time.Hour++;
                _time.Minute -= 60;
            }
            if (_time.Hour >= 24)
            {
                _time.Hour -= 24;
            }
            OnChangeTime?.Invoke(_time);
        }
    }
}

[Serializable]
public struct Time
{
    public int Hour;
    public int Minute;
    public int Second;
}
