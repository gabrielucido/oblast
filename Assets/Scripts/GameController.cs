using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public Grid grid;
    public Tilemap tilemap;


    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (grid == null) {
            Debug.LogError("2D Grid is not set on GameController Script");
        };
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not set on GameController Script");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0)) // Check for right mouse button click
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var tilePosition = grid.WorldToCell(worldPosition);

            if (tilemap.GetTile(tilePosition))
            {
                Debug.Log("Tile");
            }
            else
            {
                Debug.Log("No Tile");
            }
        }
    }
}
