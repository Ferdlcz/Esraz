using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI txtCrono;
    [SerializeField] private float time;

    private int minuteTime, secondsTime, dcTime;

    void Chronometer(){
        time -= Time.deltaTime;

        minuteTime = Mathf.FloorToInt(time / 60);
        secondsTime = Mathf.FloorToInt(time % 60);
        dcTime = Mathf.FloorToInt((time % 1) * 100);

        txtCrono.text = string.Format("{0:00}:{1:00}:{2:00}", minuteTime, secondsTime, dcTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 3600;
    }

    // Update is called once per frame
    void Update()
    {
        Chronometer();
    }

 }

