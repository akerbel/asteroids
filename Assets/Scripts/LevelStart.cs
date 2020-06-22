using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    public int asteroidCount = 2;
    public float minSpeed = 150.0f;
    public float maxSpeed = 300.0f;

    [SerializeField] private GameObject asteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < asteroidCount; i++) {
            float verticalSize = (float)(Camera.main.orthographicSize);
            float horizontalSize = (float)(verticalSize * Screen.width / Screen.height);

            float speed = Random.Range(0, +maxSpeed);
            float angle = Random.Range(0, 360);
            float posY = Random.Range(-verticalSize, verticalSize);
            float posX = Random.Range(-horizontalSize, horizontalSize);

            GameObject asteroid = Instantiate(asteroidPrefab) as GameObject;
            asteroid.transform.position = new Vector2(posX, posY);
            
            AsteroidMoving moving = asteroid.GetComponent<AsteroidMoving>();
            moving.speed = speed;
            asteroid.transform.Rotate(0, 0, angle);
        }
    }
    
}
