using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public enum TileTypes
    {
        Ground,
        FirePit,
        Forest,
        Logs,
        Water,
        StoneAgeHut,
    }

    public TileTypes tileType;
    public Vector3Int position;

    public Node(Vector3Int _position, TileTypes _tyleType)
    {
        tileType = _tyleType;
        position = _position;
    }

    public bool isWalkable
    {
        get
        {
            switch (tileType)
            {
                case TileTypes.Water:
                    return false;
                case TileTypes.Forest:
                    return true;
                case TileTypes.Ground:
                    return true;
                case TileTypes.FirePit:
                    return true;
                case TileTypes.Logs:
                    return true;
                default:
                    return true;
            }
        }
    }

    public int cost
    {
        get
        {
            switch (tileType)
            {
                case TileTypes.Ground:
                    return 1;
                case TileTypes.Forest:
                    return 4;
                case TileTypes.FirePit:
                    return 2;
                case TileTypes.Logs:
                    return 3;
                default:
                    return 0;
            }
        }
    }
}
