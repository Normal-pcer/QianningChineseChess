using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConvertPos;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // check space key pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.x -= 1;
            transform.position = pos;
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.x += 1;
            transform.position = pos;
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            Vector3 pos = transform.position;
            pos.y += 1;
            transform.position = pos;
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector3 pos = transform.position;
            pos.y -= 1;
            transform.position = pos;
        }
    }
}
