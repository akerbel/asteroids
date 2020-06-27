using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float direction = 0.0f;

    [SerializeField] private GameObject childAsteroidPrefab;
    public int childAsteroidCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletMoving movingObject = other.GetComponent<BulletMoving>();

        if (movingObject != null) {
            Destroy(other.gameObject);

            float posX = transform.position.x;
            float posY = transform.position.y;
            Destroy(gameObject);

            if (childAsteroidCount != null) {
                for (int i = 0; i < childAsteroidCount; i++) {
                    GameObject childAsteroid = Instantiate(childAsteroidPrefab) as GameObject;
                    childAsteroid.transform.position = new Vector2(posX + (i), posY);
                    Vector2 vector = new Vector2(
                        Random.Range(-500, 500),
                        Random.Range(-500, 500)
                    );
                    childAsteroid.GetComponent<Rigidbody2D>().AddForce(vector);
                }
            }

        }
    }

}
