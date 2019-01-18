using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour {



    // Vars for card mouseover behavoir
    private float zoomScale = 1.05f;

    //Vars for card flip behavoir
    private float flipSpeed = 5f;
    public Sprite back;
    public Sprite zero;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public SpriteRenderer cardSprite;
    public bool flipped = false;
    private bool flipping = false;
    public bool unflipping = false;
    private bool spriteChanged = false;

    public GameObject gameCoordinator;
    public GameCoordinator coordinatorScipt;
    public int cardID;
    public int positionX;
    public int positionY;
    private Vector3 targetPos;
    private float positionRate = 0.2f;
    private float spacing = 3;
    private bool positioned = false;

    private void Start()
    {
        cardSprite = GetComponent<SpriteRenderer>();
        targetPos = new Vector3(positionX * spacing, positionY * spacing, 0);
        gameCoordinator = GameObject.Find("GameCoordinator");
        coordinatorScipt = gameCoordinator.GetComponent<GameCoordinator>();
    }

    private void Update()
    {
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
                coordinatorScipt.hold = false;
            }
        }
        if (unflipping == true)
        {
            transform.Rotate(new Vector3(0, - flipSpeed, 0));
            if (transform.eulerAngles.y <= 90 && spriteChanged == true)
            {
                cardSprite.sprite = back;
                spriteChanged = false; 
            }
            if (transform.eulerAngles.y >= 180 && unflipping == true)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                unflipping = false;
                coordinatorScipt.hold = false;
            }
            flipped = false;
        }
        // Define card positioning movement
        if (positioned == false)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, positionRate);
            if (transform.position == targetPos)
            {
                positioned = true;
            }
        }

    }

    private void OnMouseOver()
    {
        transform.localScale = new Vector3(zoomScale, zoomScale, 0);
        if (Input.GetButtonDown("Fire1") && coordinatorScipt.hold == false && flipped == false)
        {
            flipped = true;
            flipping = true;
            coordinatorScipt.hold = true;
            gameCoordinator.SendMessage("cardClicked", gameObject);
        }
    }

    private void OnMouseExit()
    {
        transform.localScale = new Vector3(1.0f, 1.0f, 0);
    }
}
