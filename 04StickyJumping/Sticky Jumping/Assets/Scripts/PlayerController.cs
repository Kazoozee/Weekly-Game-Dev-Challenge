using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb;
    private float runSpeed = 10;
    private float topRunSpeed = 5;
    private float horizontalAirSpeed = 2;
    private float breakingForce = 10;
    private float jumpForce = 300;
    private float moveVertical;
    public bool grounded = false;

	// Use this for initialization
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
            moveVertical = jumpForce;
        }
        else
        {
            moveVertical = 0.0f;
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

        rb.AddForce(movement);
        transform.rotation = Quaternion.identity;
    }
}
