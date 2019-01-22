using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    public GameObject player;
    private float angle;
    private float firedAngleX;
    private float firedAngleY;
    private float radius = 0.45f;
    private float fireSpeed = 0.1f;
    private float fuse = 3.0f;
    private float fireTime;
    private float loadTime;
    private bool fired = false;
    private Vector3 mousePos;

	void Start () {
        player = GameObject.Find("Player");
        loadTime = Time.timeSinceLevelLoad;
	}

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && fired == false)
        {
            firedAngleX = mousePos.x;
            firedAngleY = mousePos.y;
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
        }
        if (fired == true)
        {
            transform.position = transform.position + new Vector3(firedAngleX * fireSpeed, firedAngleY * fireSpeed, 0.0f);
        }
	}

    private void Explode()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "environment" || collision.gameObject.tag == "ground" && fired == true)
        {
            Explode();
        }
    }
}
