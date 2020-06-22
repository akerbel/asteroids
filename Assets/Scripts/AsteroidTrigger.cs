using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletMoving movingObject = other.GetComponent<BulletMoving>();
        
        if (movingObject != null) {
            Debug.Log("Hit!");
            // @todo really destroy bullet
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
