using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeZ : MonoBehaviour
{
    float speed;
    bool isForward = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(1.0f, 20.0f);

        if (transform.position.z < 25.0f && isForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (transform.position.z > 1 && !isForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -speed);
        }
        else
        {
            isForward = !isForward;
        }
    }
}
