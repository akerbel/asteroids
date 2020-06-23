using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    public float speed = 6.0f;
    public float direction = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, direction);
        GetComponent<Moving>().Move(speed);
    }

}
