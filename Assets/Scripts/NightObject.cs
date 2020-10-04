using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TimeManager.instance.onMorning.AddListener(OnMorning);
        TimeManager.instance.onEvening.AddListener(OnEvening);
    }

    void OnMorning(){
        gameObject.SetActive(false);
    }

    void OnEvening(){
        gameObject.SetActive(true);
    }
}
