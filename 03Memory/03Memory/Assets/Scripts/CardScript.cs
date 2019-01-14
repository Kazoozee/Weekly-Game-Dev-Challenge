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

    //Vars for card flip behavoir
    private float flipSpeed = 1.5f;
    public Sprite back;
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public SpriteRenderer cardSprite;
    public bool flipped = false;
    private bool flipping = false;
    private bool spriteChanged = false;

    public int cardID;
    public int positionX;
    public int positionY;
    private float spacing = 3;
    private bool positioned = false;

    private void Start()
    {
        cardSprite = GetComponent<SpriteRenderer>();
    }

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
        // Define behavior for card flipping over
        if (flipping == true)
        {
            transform.Rotate(new Vector3(0, flipSpeed, 0));
            if (transform.eulerAngles.y >= 90 && spriteChanged == false)
            {
                switch(cardID)
                {
                    case 0:
                        cardSprite.sprite = zero;
                        spriteChanged = true;
                        break;
                    case 1:
                        cardSprite.sprite = one;
                        spriteChanged = true;
                        break;
                    case 2:
                        cardSprite.sprite = two;
                        spriteChanged = true;
                        break;
                    case 3:
                        cardSprite.sprite = three;
                        spriteChanged = true;
                        break;
                    default:
                        Debug.Log("cardID is " + cardID + " this may be out of range.");
                        break;
                }
            }
            if (transform.eulerAngles.y >= 180 && flipping == true)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                flipping = false;
            }
        }
        // Define card positioning movement
        if (positioned == false)
        {
            transform.position = new Vector3(positionX * spacing, positionY * spacing, 0);
        }

    }

    private void OnMouseOver()
    {
        dancing = true;
        transform.localScale = new Vector3(zoomScale, zoomScale, 0);
        if (Input.GetButtonDown("Fire1") && flipped == false)
        {
            flipped = true;
            flipping = true;
        }
    }

    private void OnMouseExit()
    {
        dancing = false;
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
    }
}
