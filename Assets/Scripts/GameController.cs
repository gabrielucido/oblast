using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    private Camera mainCamera;
    public Grid grid;
    public Tilemap tilemap;
    public IsometricRuleTile grassTile;
    public IsometricRuleTile logTile;

    public GameObject lightingPrefab;

    public int wood = 0;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {

            var tilePosition = GetTilePosition(0);
            if (tilemap.HasTile(tilePosition))
            {
                var oldTile = tilemap.GetTile<IsometricRuleTile>(tilePosition);

                if (oldTile.name == "Forest Ruletile") {
                    OnHarvestForest(tilePosition);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instantiatedPrefab = Instantiate(lightingPrefab, Vector3.zero, Quaternion.identity);
            instantiatedPrefab.GetComponent<LightningController>().OnLighting(GetTilePosition(2));
        }
    }

    public Vector3Int GetTilePosition(int z = 0)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var tilePosition = grid.WorldToCell(worldPosition);

        return new Vector3Int(tilePosition.x, tilePosition.y, z);
    }

    void OnHarvestForest(Vector3Int tilePosition)
    {
        wood += 10;
        tilemap.SetTile(new Vector3Int(tilePosition.x, tilePosition.y, 0), grassTile);
        tilemap.SetTile(new Vector3Int(tilePosition.x, tilePosition.y, 1), logTile);
    }
}
