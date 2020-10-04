using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TimeManager.instance.onMorning.AddListener(OnMorning);
        TimeManager.instance.onEvening.AddListener(OnEvening);
    }

    void OnMorning(){
        gameObject.SetActive(true);
    }

    void OnEvening(){
        gameObject.SetActive(false);
    }
}
