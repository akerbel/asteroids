using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : MonoBehaviour
{
    private float verticalSize;
    private float horizontalSize;
    public float speed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        verticalSize = (float)(Camera.main.orthographicSize * 2.0);
        horizontalSize = (float)(verticalSize * Screen.width / Screen.height);
    }

    void Update() 
    {
        Vector2 newVector = new Vector2(0, speed * Time.deltaTime);
        transform.Translate(newVector);

        sceenEdgeDestroy();
    }

    private void sceenEdgeDestroy()
    {
        if ((transform.position.y > ((verticalSize / 2) + 1)) ||
           (transform.position.y < -((verticalSize / 2) + 1)) ||
           (transform.position.x > (horizontalSize / 2)) ||
           (transform.position.x < -(horizontalSize / 2))
        ) {
            Destroy(gameObject);
        }
    }

}
