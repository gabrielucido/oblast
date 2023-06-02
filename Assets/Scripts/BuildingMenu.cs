using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingMenu : MonoBehaviour
{

    

    [SerializeField] private GameObject BuildingPanel;
    [SerializeField] private GameObject MainTilemap;


    private void Start()
    {
        
    }
    public void OpenBuildPanel()
    {
        BuildingPanel.SetActive(true);
        GridOn();
    }

    public void CloseBuildPanel()
    {
        BuildingPanel.SetActive(false);
        GridOff();
    }


    public void GridOn()
    {
       MainTilemap.SetActive(true);
    }

    public void GridOff()
    {
        MainTilemap.SetActive(false);
    }
}
