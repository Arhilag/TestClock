using System;

public class AlarmModel
{
    private Time _alarmTime;
    public Time AlarmTime => _alarmTime;
    private bool _alarmComplete;
    public bool AlarmComplete => _alarmComplete;
    
    public Action<Time> OnChangeTimeData;

    public AlarmModel()
    {
        _alarmTime = new Time();
    }
    
    public void ChangeTime(Time time)
    {
        _alarmTime = time;
        OnChangeTimeData?.Invoke(_alarmTime);
    }

    public void SetComplete()
    {
        _alarmComplete = true;
    }
}
