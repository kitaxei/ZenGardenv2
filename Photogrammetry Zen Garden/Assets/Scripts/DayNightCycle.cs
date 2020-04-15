using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    [Header("Time")]
    [Tooltip("Day Length in Minutes")]

    [SerializeField]
    [Range (0f, 1f)]
    private float _timeOfDay;
    public float timeOfDay
    {
        get
        {
            return _timeOfDay;
        }
    }
    [SerializeField]
    private float _targetDayLength = 2f; //setting day length to 2 minutes
    public float targetDayLength
    {
        get
        { 
            return _targetDayLength;
        }
    }

    [SerializeField]
    private int _dayNumber = 0; //tracks days passed
    public int dayNumber
    {
        get
        {
            return _dayNumber;
        }
    }
    [SerializeField]
    private int _yearNumber = 0;
    public int yearNumber
    {
        get
        {
            return _yearNumber;
        }
    }
    private float _timeScale = 100f;
    [SerializeField]
    private int _yearLength = 100;
    public float yearLength
    {
        get
        {
            return _yearLength;
        }
    }
    public bool pause = false;

    [Header("Sun Light")]
    [SerializeField]
    private Transform dailyRotation;

    private void Update()
    {
        if(!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }

        AdjustSunRotation();
    }
    
    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLength / 60);

    }
    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400; // seconds in a day
        if(_timeOfDay > 1) //newday
        {
            _dayNumber++;
            _timeOfDay -= 1;

            if(_dayNumber > _yearLength) //new year!
            {
                _yearNumber++;
                _dayNumber = 0;
            }
        }
    }
    //rotates the sun daily (and seasonally)
    private void AdjustSunRotation()
    {
        float sunAngle = timeOfDay * 350f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }

}



