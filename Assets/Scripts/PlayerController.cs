﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 200.0f;
    public float rotateSpeed = 120.0f;

    private float speed = 0.0f;

    [SerializeField] private GameObject weaponPrefab;

    [SerializeField] private ParticleSystem particalSystem;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
        particalSystem.Stop();
    }

    void FixedUpdate()
    {
        Rotate();
        Move();
    }

    void Update()
    {
        Shoot();
    }

    private void Move()
    {
        Rigidbody2D rb2D = GetComponent<Rigidbody2D>();
        float newSpeed = Input.GetAxis("Vertical") * velocity * Time.deltaTime;
        EngineSparks(newSpeed);
        speed = newSpeed;
        Vector2 vector = new Vector2(0, speed);
        vector = rb2D.GetRelativeVector(vector);
        rb2D.AddForce(vector);
    }

    private void Rotate()
    {
        float angle = Input.GetAxis("Horizontal") * rotateSpeed * (-1);
        angle *= Time.deltaTime;
        transform.Rotate(0, 0, angle);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject bullet = Instantiate(weaponPrefab) as GameObject;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }

    // Generate engine sparcks in Particular System.
    private void EngineSparks(float newSpeed) 
    {
        if ((newSpeed >= speed) && (speed != 0)) {
            particalSystem.Emit((int)newSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Asteroid") {
            Debug.Log(collision.collider.name);
            Destroy(gameObject);
        }
    }
}
