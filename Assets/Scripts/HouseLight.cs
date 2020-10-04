using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HouseLight : MonoBehaviour
{
    Light2D houseLight;

    void OnEnable()
    {
        StartCoroutine(LightOpenAnimation());
    }

    void Awake()
    {
        houseLight = GetComponent<Light2D>();
    }

    IEnumerator LightOpenAnimation(){
        float timeCnt = 0;
        while(timeCnt < 0.6f){

            if(timeCnt <= 0.2f){
                houseLight.enabled = false;
            }
            else if(timeCnt >= 0.3f && timeCnt <= 0.4f){
                houseLight.enabled = false;
            }
            else if(timeCnt >= 0.5f){
                houseLight.enabled = false;
            }
            else{
                houseLight.enabled = true;
            }

            timeCnt += Time.deltaTime;
            yield return 0;
        }
        houseLight.enabled = true;
    }
}
