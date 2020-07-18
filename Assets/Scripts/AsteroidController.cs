using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public float direction = 0.0f;

    [SerializeField] private GameObject childAsteroidPrefab;
    public int childAsteroidCount = 2;

    public float noCollisionTime = 1.0f;

    public bool active = true;

    public int hp = 3;
    private int maxHp;
    [SerializeField] private ParticleSystem particalSystem;
    [SerializeField] private ParticleSystem hitBlows;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction);
        StartCoroutine(NoCollision(noCollisionTime));
        hitBlows.Stop();
        maxHp = hp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (active) {
            BulletMoving movingObject = other.GetComponent<BulletMoving>();

            if (movingObject != null) {

                // If not to destroy the bullet right now, 
                // it will trigger child asteroids.
                Destroy(movingObject.gameObject);

                hp -= 1;
                HitEffects();

                if (hp <= 0) {
                    Crush();
                    ScoreController.AddScore(maxHp * 100);
                }
            }
        }
    }

    private void HitEffects(int particlesCount = 1000)
    {
        hitBlows.Emit(particlesCount);
        var emission = particalSystem.emission;
        emission.rateOverTime = (maxHp - hp) * 50;
        var main = particalSystem.main;
        main.simulationSpeed = (maxHp - hp + 1);
    }

    /**
     * Crush the asteroid to child asteroids
     */
    private void Crush()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        active = false;
        StartCoroutine(BlowAnimation());

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

    IEnumerator BlowAnimation(float time = 1.0f)
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
