using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Control;
using static ConvertPos;

public class Each : MonoBehaviour
{

    double pow(double a, int b)
    {
        double result = 1.0;
        for (int i = 0; i < b; i++)
            result = result * a;
        return result;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject red = GameObject.Find("red-point");
        GameObject black = GameObject.Find("black-point");

        red.transform.position = new Vector3(-3.5f, 0, 0);
        black.transform.position = new Vector3(11.4514f, 19.19f, 8.10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get Position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // Get Object Position
            Vector3 objectPosition = transform.position;
            // Check if the mouse is on the object(size = 0.4*0.4)
            if ((pow(mousePosition.x - objectPosition.x, 2) + pow(mousePosition.y - objectPosition.y, 2)) <= pow(0.4, 2))
            {
                // Output Object Name
                Select(gameObject.name);
            }
            else
            {
                Move(gameObject.name, NearestBlock(mousePosition));
            }
        }
        if (CheckSelected(gameObject.name))
        {
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1.0f);

        }
    }
}
