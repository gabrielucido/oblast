using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGenerator : MonoBehaviour
{
    public int stone = 0;
    void Start()
    {
        InvokeRepeating("GenerateStone", 2.0f, 4.0f);   
    }

    void GenerateStone()
    {
        stone++;
    }
}
