using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float direction = 0.0f;

    [SerializeField] private GameObject childAsteroidPrefab;
    public int childAsteroidCount = 2;

    public float noCollisionTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction);
        StartCoroutine(NoCollision(noCollisionTime));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        BulletMoving movingObject = other.GetComponent<BulletMoving>();

        if (movingObject != null) {
            StartCoroutine(movingObject.Hit());

            float posX = transform.position.x;
            float posY = transform.position.y;
            StartCoroutine(Hit());

            if (childAsteroidCount > 0) {
                for (int i = 0; i < childAsteroidCount; i++) {
                    GameObject childAsteroid = Instantiate(childAsteroidPrefab) as GameObject;
                    childAsteroid.transform.position = new Vector2(posX, posY);
                    Vector2 vector = new Vector2(
                        Random.Range(-500, 500),
                        Random.Range(-500, 500)
                    );
                    childAsteroid.GetComponent<Rigidbody2D>().AddForce(vector);
                }
            }
        }
    }

    IEnumerator Hit()
    {
        GetComponent<Animator>().SetBool("hit", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    public IEnumerator NoCollision(float time = 1.0f)
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        yield return new WaitForSeconds(time);
        collider.isTrigger = false;
    }
}
