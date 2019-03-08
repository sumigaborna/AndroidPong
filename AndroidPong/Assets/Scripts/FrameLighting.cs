using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script controlls edge lighting, time and colour

public class FrameLighting : MonoBehaviour {

    Light SpotLight;
    private float MyTimeCounter=4f;

	// Use this for initialization
	void Start () {
        SpotLight = this.GetComponent<Light>();
        SpotLight.spotAngle = 1;
        SpotLight.range = 1;
        
    }
	
	// Update is called once per frame
	void Update () {
        MyTimeCounter -= Time.deltaTime;
        
        if (MyTimeCounter > 0)
        {
            
            SpotLight.spotAngle +=(float)0.1;
            SpotLight.range += 10;
            
        }
        if (MyTimeCounter < 0)
        {
            
            SpotLight.spotAngle -= (float)0.1;
            SpotLight.range -= 10;
            if(SpotLight.range == 1) //returns counter back to 5 seconds, so lighting can loop properly 
            {
                MyTimeCounter = 4f;
                SpotLight.color = UnityEngine.Random.ColorHSV(); //picks random color of lighting after before loop starts again
            }
        }
    }
}
