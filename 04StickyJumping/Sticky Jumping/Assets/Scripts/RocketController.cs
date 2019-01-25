using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    public GameObject player;
    public GameObject explosion;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float angle;
    private float firedAngleX;
    private float firedAngleY;
    private float radius = 0.1f;
    public float fireSpeed = 100f;
    private float firedAngle;
    private float fuse = 3.0f;
    private float fireTime;
    private float loadTime;
    private bool fired = false;
    private bool positioned = false;
    private Vector3 mousePos;

	void Start () {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        loadTime = Time.timeSinceLevelLoad;
	}

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && fired == false)
        {
            firedAngle = angle;
            fired = true;
            fireTime = Time.time;
        }
        if (Time.time >= fireTime + fuse && fired == true)
        {
            Explode();
        }

    }

    void FixedUpdate () {
		
        if (fired == false)
        {
            mousePos = Input.mousePosition;
            mousePos.z = (player.transform.position.z - Camera.main.transform.position.z);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            mousePos = mousePos - player.transform.position;
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.localEulerAngles = new Vector3(0, 0, angle);
            float xPos = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            float yPos = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            transform.localPosition = new Vector3(player.transform.position.x + xPos, player.transform.position.y + yPos, 0);
            if (positioned == false)
            {
                spriteRenderer.enabled = true;
                positioned = true;
            }
        }
        if (fired == true)
        {
            Vector3 dir = Quaternion.AngleAxis(firedAngle, Vector3.forward) * Vector3.right;
            rb.AddForce(dir * fireSpeed);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fired == true && collision.gameObject.tag != "Player")
        {
            Explode();
        }
    }

    private void Explode()
    {
        player.SendMessage("Explosion", transform.position);
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
