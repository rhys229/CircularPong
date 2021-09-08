using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ballScript : MonoBehaviour
{
    private Vector3 position;
    private Rigidbody2D rb;

    public float force;

    public float angle;

    public int state;

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        state = 0;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(0, 0,0);
        launchBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == 0)
        {
            sr.color = Color.white;
        }
        else if (state == 1)
        {
            sr.color = Color.red;
        }
        else if (state == 2)
        {
            sr.color = Color.blue;
        }
    }

    void launchBall()
    {
        transform.position = new Vector3(0, 0,0);
        angle = Random.Range(0, 360);
        float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;
        Debug.Log(xcomponent);
        Debug.Log(angle);
        rb.AddForce(new Vector2(xcomponent,ycomponent));
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "paddle1")
        {
            state = 1;
        }
        if (other.gameObject.name == "paddle2")
        {
            state = 2;
        }
    }
}
