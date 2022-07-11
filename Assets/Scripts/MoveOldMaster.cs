using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConvertPos;

public class MoveOldMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // When mouse button clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = NearestBlock(new Vector3(mousePosition.x, mousePosition.y, 0));
        }
    }
}
