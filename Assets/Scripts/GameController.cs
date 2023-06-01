using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{

    public Grid grid;
    public Tilemap tilemap;

    [SerializeField]
    public List<Sprite> sprites;

    private Camera mainCamera;

    public IsometricRuleTile GrassTile;

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

        if (grid != null && tilemap != null)
        {
            var availablePlaces = new List<Vector3>();

            for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
            {
                for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
                {
                    Vector3Int localPlace = (new Vector3Int(n, p, (int)tilemap.transform.position.y));
                    Vector3 place = tilemap.CellToWorld(localPlace);
                    if (tilemap.HasTile(localPlace))
                    {   
                        //Tile at "place"
                        Debug.Log("place");
                        Debug.Log(localPlace);
                        availablePlaces.Add(place);
                        Debug.Log(tilemap.GetTile(localPlace));
                    }
                    else
                    {
                        //Debug.Log("No place");
                    }
                }
            }
        }

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var tilePosition = grid.WorldToCell(worldPosition);

            int zTilePosition = 0;

            tilePosition = new Vector3Int(tilePosition.x, tilePosition.y, zTilePosition);

            if (tilemap.HasTile(tilePosition))
            {
                var oldTile = tilemap.GetTile<IsometricRuleTile>(tilePosition);

                if (oldTile.name == "Forest Ruletile")
                {
                    IsometricRuleTile newTile = ScriptableObject.CreateInstance<IsometricRuleTile>();
                    newTile.m_DefaultSprite = sprites[2];
                    tilemap.SetTile(new Vector3Int(tilePosition.x, tilePosition.y, 0), newTile);

                    IsometricRuleTile newTile2 = ScriptableObject.CreateInstance<IsometricRuleTile>();
                    newTile2.m_DefaultSprite = sprites[1];
                    tilemap.SetTile(new Vector3Int(tilePosition.x, tilePosition.y, 1), newTile2);
                }
            }
            else
            {
                Debug.Log("No Tile");
            }
        }
    }
}
