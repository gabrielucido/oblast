using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NPCController : MonoBehaviour
{
    Pathfinding pathfinding;
    public Tilemap tilemap;
    public Grid grid;

    public float speed = 10f;
    public Vector3? currentTarget;
    public Queue<Node> currentQueueTarget = new Queue<Node>();

    void Update()
    {
        MoveTo();
    }

    private void Start()
    {
        if (grid == null)
        {
            grid = GameObject.Find("Grid").GetComponent<Grid>();
        }
        if (tilemap == null)
        {
            tilemap = GameObject.Find("Tilemap").GetComponent<Tilemap>();
        }

        pathfinding = GetComponent<Pathfinding>();
        Vector3Int start = tilemap.WorldToCell(transform.position);
        transform.position = GridToWorldNormalizedPosition(start);
        //Vector3Int goal = new Vector3Int(-1, -1, 0);
        //Queue<Node> queue = pathfinding.Dijkstra(start, goal);
        //Debug.Log(queue.Count);

        // TODO: Check if player already are above a forest.. ELSE Continue

        List<Node> forestNodes = pathfinding.GetTypedNodes(Node.TileTypes.Forest);

        Queue<Node> queueToClosestForest = null;
        int stepsToClosestForest = -1;

        foreach (Node node in forestNodes)
        {
            var queue = pathfinding.Dijkstra(start, node.position);
            if (queue != null)
            {
                if (queue.Count < stepsToClosestForest || stepsToClosestForest == -1)
                {
                    queueToClosestForest = queue;
                    stepsToClosestForest = queue.Count;
                }
            }
        }

        if (queueToClosestForest != null)
        {
            //while (queueToClosestForest.Count > 0)
            //{
            //    Node node = queueToClosestForest.Dequeue();
            //}
            currentQueueTarget = queueToClosestForest;
        }
    }

    Vector3 GridToWorldNormalizedPosition(Vector3Int position)
    {
        return grid.CellToLocalInterpolated(new Vector3(position.x + .5f, position.y + .5f, position.z));
    }

    void MoveTo()
    {
        if (this.currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, (Vector3)this.currentTarget, this.speed * Time.deltaTime);
        }

        if (currentQueueTarget.Count > 0)
        {
            if (this.currentTarget == null)
            {
                Node node = this.currentQueueTarget.Dequeue();
                this.currentTarget = GridToWorldNormalizedPosition(node.position);
            }
            else if (transform.position == this.currentTarget)
            {
                this.currentTarget = null;
            }
        }
    }
}
