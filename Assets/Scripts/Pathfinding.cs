using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Pathfinding : MonoBehaviour
{
    public Tilemap tilemap;
    public Grid grid;

    public List<Node> nodes = new List<Node>();

    public List<Node> GetAllNodes()
    {
        if (grid == null && tilemap == null)
        {
            throw new System.Exception("Grid or Tilemap has not ben set in inspector!");
        }

        for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++)
        {
            for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            {
                Vector3Int position = (new Vector3Int(n, p, (int)tilemap.transform.position.y));
                if (tilemap.HasTile(position))
                {
                    var tyleType = Node.TileTypes.Ground;
                    if (tilemap.name == "WaterRuletile")
                    {
                        tyleType = Node.TileTypes.Water;
                    }
                    else if (tilemap.name == "ForestRuletile")
                    {
                        tyleType = Node.TileTypes.Forest;
                    }
                    else
                    {
                        tyleType = Node.TileTypes.Ground;
                    }
                    nodes.Add(new Node(position, tyleType));
                }
            }

        }
        return nodes;
    }

    public Node GetNodeByPosition(Vector3Int position)
    {
        foreach (Node node in nodes)
        {
            if (node.position == position)
            {
                return node;
            }
        }
        return null;
    }

    List<Node> GetNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        if (GetNodeByPosition(new Vector3Int(node.position.x, node.position.y + 1, node.position.z)) != null)
        {
            neighbors.Add(GetNodeByPosition(new Vector3Int(node.position.x, node.position.y + 1, node.position.z)));
        }

        if (GetNodeByPosition(new Vector3Int(node.position.x + 1, node.position.y, node.position.z)) != null)
        {
            neighbors.Add(GetNodeByPosition(new Vector3Int(node.position.x + 1, node.position.y, node.position.z)));
        }

        if (GetNodeByPosition(new Vector3Int(node.position.x, node.position.y - 1, node.position.z)) != null)
        {
            neighbors.Add(GetNodeByPosition(new Vector3Int(node.position.x, node.position.y - 1, node.position.z)));
        }

        if (GetNodeByPosition(new Vector3Int(node.position.x - 1, node.position.y, node.position.z)) != null)
        {
            neighbors.Add(GetNodeByPosition(new Vector3Int(node.position.x - 1, node.position.y, node.position.z)));
        }
        // TODO: Get Corner Neighbors
        return neighbors;
    }

    public Queue<Node> Dijkstra(Vector3Int startPosition, Vector3Int goalPosition)
    {
        GetAllNodes();
        Node start = GetNodeByPosition(startPosition);
        Node goal = GetNodeByPosition(goalPosition);

        if (start == null || goal == null)
        {
            Debug.Log("Start or Goal is Unreachable!");
            return null;
        }

        Dictionary<Node, Node> NextTileToGoal = new Dictionary<Node, Node>();
        Dictionary<Node, int> costToReachTile = new Dictionary<Node, int>();
        PriorityQueue<Node> frontier = new PriorityQueue<Node>();

        frontier.Enqueue(goal, 0);
        costToReachTile[goal] = 0;

        while (frontier.Count > 0)
        {
            Node curNode = frontier.Dequeue();
            if (curNode == start)
                break;
            foreach (Node neighbor in GetNeighbors(curNode))
            {
                int newCost = costToReachTile[curNode] + neighbor.cost;
                if (costToReachTile.ContainsKey(neighbor) == false || newCost < costToReachTile[neighbor])
                {
                    //if (neighbor._TileType != Node.TileType.Wall)
                    //{
                    costToReachTile[neighbor] = newCost;
                    int priority = newCost;
                    frontier.Enqueue(neighbor, priority);
                    NextTileToGoal[neighbor] = curNode;
                    //neighbor._Text = costToReachTile[neighbor].ToString();
                    //}
                }
            }
        }

        if (NextTileToGoal.ContainsKey(start) == false)
        {
            return null;
        }

        Queue<Node> path = new Queue<Node>();
        Node pathTile = start;
        while (goal != pathTile)
        {
            pathTile = NextTileToGoal[pathTile];
            path.Enqueue(pathTile);
        }
        return path;
    }

    //public void Update()
    //{
    //    var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    var mousePosition = grid.WorldToCell(worldPosition);

    //    int z = 0;

    //    mousePosition = new Vector3Int(mousePosition.x, mousePosition.y, z);

    //    if (tilemap.HasTile(mousePosition))
    //    {
    //        Debug.Log("Found IT!!!");
    //    }
    //    Debug.Log(mousePosition);

    //}
}
