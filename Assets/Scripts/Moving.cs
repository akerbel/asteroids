using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float verticalSize;
    private float horizontalSize;
    private Vector2 vector;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        vector = new Vector2(0, 0);
        rb2D = GetComponent<Rigidbody2D>();
        verticalSize = (float)(Camera.main.orthographicSize * 2.0);
        horizontalSize = (float)(verticalSize * Screen.width / Screen.height);
    }

    public void Move(float speed)
    {
        Vector2 newVector = new Vector2(0, speed * Time.deltaTime);
        vector = rb2D.GetRelativeVector(newVector);
        rb2D.AddForce(vector);
    }

    private void sceenEdgeTeleport()
    {
        if (transform.position.y > ((verticalSize / 2) + 1)) {
            transform.Translate(0, -(verticalSize + 2), 0, Space.World);
        }
        if (transform.position.y < -((verticalSize / 2) + 1)) {
            transform.Translate(0, verticalSize + 2, 0, Space.World);
        }
        if (transform.position.x > (horizontalSize / 2)) {
            transform.Translate(-(horizontalSize + 2), 0, 0, Space.World);
        }
        if (transform.position.x < -(horizontalSize / 2)) {
            transform.Translate(horizontalSize + 2, 0, 0, Space.World);
        }
    }

    void Update()
    {
        sceenEdgeTeleport();
    }

}
