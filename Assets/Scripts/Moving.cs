using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private float verticalSize;
    private float horizontalSize;

    // Start is called before the first frame update
    void Start()
    {
        verticalSize = (float)(Camera.main.orthographicSize * 2.0);
        horizontalSize = (float)(verticalSize * Screen.width / Screen.height);
    }

    void Update()
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

}
