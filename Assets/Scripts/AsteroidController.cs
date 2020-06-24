using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public float speed = 0.0f;
    public float direction = 0.0f;

    [SerializeField] private GameObject childAsteroidPrefab;
    public int childAsteroidCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction);
        GetComponent<Moving>().Move(speed);
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
                    childAsteroid.transform.position = new Vector2(posX + (i * 100), posY);
                    childAsteroid.GetComponent<AsteroidController>().speed = speed + 1000.0f;
                    childAsteroid.transform.Rotate(0, 0, Random.Range(0, 360));
                    childAsteroid.GetComponent<Moving>().Move(speed + 1000.0f);
                }
            }

        }
    }

}
