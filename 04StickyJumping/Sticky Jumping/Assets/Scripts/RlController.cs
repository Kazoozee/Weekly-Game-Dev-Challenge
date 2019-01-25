using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RlController : MonoBehaviour
{

    public GameObject player;
    public GameObject rocket;
    public GameObject rocketReloadIcon;
    private float angle;
    private float radius = 0.1f;
    private float fireTime = 0.0f;
    private float coolDown = 0.5f;
    public bool loaded = false;
    private Vector3 mousePos;

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

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && loaded == true)
        {
            loaded = false;
            fireTime = Time.time;
        }
        if (loaded == false && Time.time >= fireTime + coolDown)
        {
            rocketReloadIcon.SendMessage("Reload");
            Instantiate(rocket, Vector3.zero, Quaternion.identity);
            loaded = true;
        }
    }
}
