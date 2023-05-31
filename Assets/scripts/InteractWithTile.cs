using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractWithTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) // Check for right mouse button click
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null)
            {
                // Check if the hit object has a tile component
                Debug.Log(hit.collider.gameObject);
                Debug.Log(hit.collider.gameObject.GetComponent<TileData>().text);
                //Debug.Log(tileData.text);
            }
        }
    }
}
