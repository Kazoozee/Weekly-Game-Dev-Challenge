using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RocketReloadIconController : MonoBehaviour {

    public GameObject player;
    private float angle;
    private float radius = 0.45f;
    private bool reloaded = false;
    private Vector3 mousePos;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (reloaded == true && Input.GetButtonDown("Fire1"))
        {
            spriteRenderer.enabled = false;
            reloaded = false;
        }
    }

    private void FixedUpdate()
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

    public void Reload()
    {
        spriteRenderer.enabled = true;
        reloaded = true;
    }
}
