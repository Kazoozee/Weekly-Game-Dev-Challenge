using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {

    // Vars for card mouseover behavoir
    private float zoomScale = 1.05f;
    private float danceAngle = 5.0f;
    private float danceSpeed = 0.5f;
    private bool dancing = false;
    private bool danceReversed = false;
    private bool danceCycling = false;

    private void Update()
    {
        // Define mouse over dance behavoir
        if (dancing == true || danceCycling == true)
        {
            if (danceReversed == false)
            {
                transform.Rotate(new Vector3(0, 0, danceSpeed));
            }
            if (danceReversed == true)
            {
                transform.Rotate(new Vector3(0, 0, -danceSpeed));
            }
            if (transform.eulerAngles.z >= danceAngle && transform.eulerAngles.z <= 360 - danceAngle)
            {
               danceReversed = !danceReversed;
            }
            if (transform.eulerAngles.z != 0)
            {
                danceCycling = true;
            }
            if (transform.eulerAngles.z <= 0.1)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                danceCycling = false;
            }
        }
    }

    private void OnMouseOver()
    {
        dancing = true;
        transform.localScale = new Vector3(zoomScale, zoomScale, 0);
    }

    private void OnMouseExit()
    {
        dancing = false;
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
    }
}
