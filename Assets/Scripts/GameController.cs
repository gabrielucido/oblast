using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController : MonoBehaviour
{
    public enum GameModes
    {
        Lightning,
        Building,
        Lumberjack,
        Walk,
    }

    public GameModes gameMode = GameModes.Walk;

    private Camera mainCamera;

    public Grid grid;
    public Tilemap tilemap;

    public IsometricRuleTile grassTile;
    public IsometricRuleTile logTile;
    public IsometricRuleTile firePit;

    public GameObject lightingPrefab;

    public NPCController npcController;

    public int wood = 0;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (gameMode == GameModes.Walk)
            {
                HandleWalk();
            }
            if (gameMode == GameModes.Lightning)
            {
                HandleLightning();
            }
            if (gameMode == GameModes.Lumberjack)
            {
                HandleLumberjack();
            }
            if (gameMode == GameModes.Building)
            {
                HandleBuilding();
            }
        }
    }

    void HandleWalk()
    {
        if (tilemap.HasTile(GetMouseClickTilePosition()))
        {
            var tile = tilemap.GetTile<IsometricRuleTile>(GetMouseClickTilePosition());
            if (tile.name == "GroundRuletile" || tile.name == "LogRuletile" || tile.name == "ForestRuletile" || tile.name == "FirePitRuletile")
            {
                npcController.SetMoveTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }

    void HandleLightning()
    {
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

    void HandleLumberjack()
    {
        if (tilemap.HasTile(GetMouseClickTilePosition()))
        {
            var tile = tilemap.GetTile<IsometricRuleTile>(GetMouseClickTilePosition());
            Debug.Log(tile);
            if (tile.name == "ForestRuletile")
            {
                npcController.SetMoveTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                OnHarvestForest();
            }
        }
    }

    void HandleBuilding()
    {

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

    public void OnClickLightning()
    {
        gameMode = GameModes.Lightning;
    }

    public void OnClickBuilding()
    {
        gameMode = GameModes.Building;
    }
    public void OnClickLumberjacking()
    {
        gameMode = GameModes.Lumberjack;
    }

    public void OnClickWalk()
    {
        gameMode = GameModes.Walk;
    }
}
