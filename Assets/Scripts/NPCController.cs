using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    Pathfinding pathfinding;

    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        Vector3Int start = new Vector3Int(0, 0, 0);
        Vector3Int goal = new Vector3Int(-1, -1, 0);
        Queue<Node> queue = pathfinding.Dijkstra(start, goal);
        Debug.Log(queue.Count);

        //List<Node> nodes = pathfinding.GetAllNodes();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
