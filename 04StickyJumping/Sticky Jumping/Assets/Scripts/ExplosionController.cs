using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

    private float spawnTime;
    private float lastStepTime;
    private float stepSize = 0.1f;
    private float stepTime = 0.1f;
    private float opacity = 1;
    private SpriteRenderer sr;

	void Start () {
        spawnTime = Time.time;
        lastStepTime = spawnTime;
        sr = GetComponent<SpriteRenderer>();
	}
	
	void FixedUpdate () {
		if (Time.time > lastStepTime + stepTime)
        {
            sr.color = new Color(1f, 1f, 1f, opacity);
            opacity = opacity - stepSize;
            lastStepTime = Time.time;
        }
        if (opacity <= 0)
        {
            Destroy(gameObject);
        }
	}
}
