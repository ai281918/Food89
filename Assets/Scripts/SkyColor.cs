using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public enum SkyType{
    winter_normal,
}

[RequireComponent(typeof(Light2D))]
public class SkyColor : MonoBehaviour
{
    public SkyType skyType = SkyType.winter_normal;
    public Gradient winterNormalSkyColor;
    Light2D skyLight;
    TimeManager timeManager;

    private void Awake() {
        timeManager = TimeManager.instance;
        skyLight = GetComponent<Light2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        timeManager.onTimeChange.AddListener(UpdateSkyColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateSkyColor(float time){
        switch(skyType){
            case SkyType.winter_normal:
                skyLight.color = winterNormalSkyColor.Evaluate(time);
                break;
        }
    }
}
