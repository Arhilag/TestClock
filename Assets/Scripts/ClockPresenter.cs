using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class ClockPresenter : MonoBehaviour
{
    private ClockModel _clockModel;
    [SerializeField] private ClockView _clockView;

    public static ClockPresenter Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            return;
        }
        Destroy(this);
    }

    private void OnDestroy()
    {
        _clockModel.OnChangeTime -= _clockView.ChangeTime;
    }

    void Start()
    {
        _clockModel = new ClockModel();
        _clockModel.OnChangeTime += _clockView.ChangeTime;
        StartCoroutine(GetInternetTime("https://www.microsoft.com"));
        StartCoroutine(GetInternetTime("https://www.google.com"));
    }

    private IEnumerator GetInternetTime(string url)
    {
        UnityWebRequest myHttpWebRequest = UnityWebRequest.Get(url);
        yield return myHttpWebRequest.Send();
 
        string netTime = myHttpWebRequest.GetResponseHeader("date");
        if (netTime != null)
        {
            var time = DateTime.ParseExact(netTime,
                "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                CultureInfo.InvariantCulture.DateTimeFormat,
                DateTimeStyles.AssumeUniversal);
            _clockModel.CorrectTime(time);
        }
    }

    public Time GetTimeData()
    {
        return _clockModel.Time;
    }
}
