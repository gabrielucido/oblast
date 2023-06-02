using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
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
            if (tileType == TileTypes.Ground)
            {
                return true;
            }
            return false;
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
                    return 8;
                case TileTypes.FirePit:
                    return 4;
                case TileTypes.Logs:
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
