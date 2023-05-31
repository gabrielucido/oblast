using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    public string text = "Lorem Ipsum dolor met!!";
    
    void Start()
    {
        Debug.Log("start!!!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
            // Collision with the specific tile happened
            Debug.Log("Collision with specific tile detected.");
    }
}
