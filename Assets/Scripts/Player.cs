using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Moving
{
    public float velocity = 50.0f;
    public float rotateSpeed = 120.0f;

    [SerializeField] private GameObject weaponPrefab;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    void FixedUpdate()
    {
        this.Rotate();
        this.Move();
    }

    new void Update()
    {
        base.Update();
        this.Shoot();
    }

     private void Move()
     {
        float speed = Input.GetAxis("Vertical") * velocity;
        base.Move(speed);
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
            //print("space key was pressed");
            GameObject bullet = Instantiate(weaponPrefab) as GameObject;
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Asteroid") {
            Debug.Log(collision.collider.name);
            Destroy(this);
        }
    }
}
