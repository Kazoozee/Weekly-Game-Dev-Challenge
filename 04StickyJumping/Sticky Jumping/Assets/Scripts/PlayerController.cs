/*
 * Feature Requests;
 * 
 * Explosion Animation
 * 
 * Visual feedback for rocketJump quality (temp is in place)
 *      Good for anything over 650
 *      Great for anything over 800
 *      Perfect for anything over 925
 *      
 *
 * Audible feedback for rocket Jump quality
 *      sound for too low
 *      sound for too high
 *      sound for Perfect
 * 
 * Level Design
 *      Teach through level design
 *      Build on a concept
 *      Provide a place to figure it out danger free then add danger.
 * 
 * 
 * Bugs:
 * 
 * Occasionally a rj will have too much force. Maybe this is more than one of the collision triggers going off at once
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    public Text jumpQuality;
    public Text jumpHint;
    public float explosionMultiplier = 100;
    private float runSpeed = 10;
    private float topRunSpeed = 5;
    private float horizontalAirSpeed = 2;
    private float breakingForce = 10;
    private float jumpForce = 500;
    private float moveVertical;
    public bool grounded = false;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "hazards")
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
        }
    }

    private void FixedUpdate()
    {        
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement;

        // Movement Control
        if (grounded == true && Mathf.Abs(rb.velocity.x) < topRunSpeed)
        {
            movement = new Vector3(moveHorizontal * runSpeed, moveVertical, 0.0f);
        }
        else
        {
            movement = new Vector3(moveHorizontal * horizontalAirSpeed, moveVertical, 0.0f);
        }
       
        // Automaticly apply backwards force when the finger comes off the stick
        if (grounded == true && moveHorizontal == 0 && rb.velocity.x > 0)
        {
            movement.x = -breakingForce;
        }
        if (grounded == true && moveHorizontal == 0 && rb.velocity.x < 0)
        {
            movement.x = breakingForce;
        }
        if (movement.y > 1)
        {
            Debug.Log(movement);
        }
        rb.AddForce(movement);
        transform.rotation = Quaternion.identity;
    }

    public void Explosion(Vector3 explosionPos)
    {
        float exposionSize = 3.0f;
        float range = Vector3.Distance(explosionPos, transform.position);
        if (range < 0.95)
        {
            jumpHint.text = "Jump further\nfrom the \nexplosion!";
        }
        if (range > 1.05)
        {
            jumpHint.text = "Jump closer\nto the \nexplosion!";
        }
        if (range >= 0.9 && range <= 1.1)
        {
            jumpHint.text = " ";
        }
        if (range <= 0.5 || range >= 1.5)
        {
            jumpQuality.text = "Awful!";
        }
        else if (range <= 0.6 || range >= 1.4)
        {
            jumpQuality.text = "Okay!";
        }
        else if (range <= 0.7 || range >= 1.3)
        {
            jumpQuality.text = "Good!";
        }
        else if (range <= 0.85 || range >= 1.15)
        {
            jumpQuality.text = "Great!";
        }
        else
        {
            jumpQuality.text = "Perfect!";
        }
        Vector3 explosionForce = new Vector3(0, 0, 0);
        if (range < exposionSize)
        {
            if (range <= 1)
            {
                explosionForce = (transform.position - explosionPos) * (explosionMultiplier / (Mathf.Ceil(range) * Mathf.Ceil(range)));
            }
            else
            {
                explosionForce = (transform.position - explosionPos) * (explosionMultiplier / (range * range));
            }
        }
        rb.AddForce(explosionForce);
    }
}
