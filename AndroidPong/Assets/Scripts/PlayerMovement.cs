using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Ray ray;
    private RaycastHit rayCastHit;    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount >0)
        {
            Touch touch = Input.GetTouch(0);      
            ray = Camera.main.ScreenPointToRay(touch.position); //saves position from touch to a ray
            if(Physics.Raycast(ray, out rayCastHit)) //if the ray intersects with anything (our case: touchBox)
            {
                transform.position = new Vector2 (transform.position.x,rayCastHit.point.y); //moves paddle to Y position where the ray intersected with touchBox
            }
        }
    }
}
