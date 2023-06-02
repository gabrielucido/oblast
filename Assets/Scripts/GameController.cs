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
    public IsometricRuleTile firePit;

    public GameObject lightingPrefab;

    public int wood = 0;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tilemap.HasTile(GetMouseClickTilePosition()))
            {
                var tile = tilemap.GetTile<IsometricRuleTile>(GetMouseClickTilePosition());
                if (tile.name == "ForestRuletile") {
                    OnHarvestForest();
                    return;
                }
            }

            if (tilemap.HasTile(GetMouseClickTilePosition(1)))
            {
                var tile = tilemap.GetTile<IsometricRuleTile>(GetMouseClickTilePosition(1));
                if (tile.name == "LogRuletile")
                {
                    OnPutFireOnForest();
                    return;
                }
            }
        }
    }

    public Vector3Int GetMouseClickTilePosition(int z = 0)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var tilePosition = grid.WorldToCell(worldPosition);

        return new Vector3Int(tilePosition.x, tilePosition.y, z);
    }

    void OnHarvestForest()
    {
        wood += 10;
        tilemap.SetTile(GetMouseClickTilePosition(), grassTile);
        tilemap.SetTile(GetMouseClickTilePosition(1), logTile);
    }

    void OnPutFireOnForest()
    {
        tilemap.SetTile(GetMouseClickTilePosition(), firePit);
        tilemap.SetTile(GetMouseClickTilePosition(1), null);
        OnLightningStrike();
    }

    void OnLightningStrike()
    {
        GameObject instantiatedPrefab = Instantiate(lightingPrefab, Vector3.zero, Quaternion.identity);
        instantiatedPrefab.GetComponent<LightningController>().OnLighting(GetMouseClickTilePosition(2));
    }
}
