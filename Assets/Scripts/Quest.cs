using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    

    public List<bool> checklist = new List<bool>();
    public int index;

    private void Awake()
    {
        LightningController.OnLightingDiscovered += OnQuestComplete;
        Building.OnBuild += OnQuestComplete;
        GameController.WoodCollected += OnQuestComplete;
    }

    private void OnQuestComplete()
    {
        checklist[index] = true;
        index++;

        if(index >= checklist.Count)
        {
            Debug.Log("Proxima Fase");
        }
    }
}
