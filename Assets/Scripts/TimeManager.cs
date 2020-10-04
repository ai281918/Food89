using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
    static TimeManager _instance;
    public static TimeManager instance{
        get{
            if (_instance == null){
                _instance = FindObjectOfType(typeof(TimeManager)) as TimeManager;
                if (_instance == null){
                    GameObject go = new GameObject("TimeManager");
                    _instance = go.AddComponent<TimeManager>();
                }
            }
            return _instance;
        }
    }

    [HideInInspector]
    public UnityEvent<float> onTimeChange = new UnityEvent<float>();
    [HideInInspector]
    public UnityEvent onMorning = new UnityEvent();
    [HideInInspector]
    public UnityEvent onEvening = new UnityEvent();
    
    [HideInInspector]
    public bool isDay = false;
    public float dayLength = 10f;
    float timeCount = 0f;
    
    [Range(0f, 0.5f)]
    public float morningTime = 0.25f;
    [Range(0.5f, 1f)]
    public float eveningTime = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        morningTime *= dayLength;
        eveningTime *= dayLength;
        onEvening.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        // night
        if(timeCount < morningTime){

        }
        // day
        else if(timeCount < eveningTime){
            if(!isDay){
                isDay = true;
                onMorning.Invoke();
            }
        }
        // night
        else if(timeCount < dayLength){
            if(isDay){
                isDay = false;
                onEvening.Invoke();
            }
        }
        else{
            timeCount = 0f;
        }

        onTimeChange.Invoke(timeCount / dayLength);
    }
}
