using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
 
    public bool Placed { get; private set; }
    public BoundsInt area;

    public static int index;

    public static event Action OnBuild;

    //[SerializeField] private GameObject gameObject;
    [SerializeField] public int necessaryAmount;

    public GameController gameController;
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    #region Build Methods

    public bool CanBePlaced()
    {
        Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt; 

        if(GridBuildingSystem.current.CanTakeArea(areaTemp) && gameController.wood >= necessaryAmount)
        {
                return true;  
        }

        return false;
    }

    public void Place()
    {
            Vector3Int positionInt = GridBuildingSystem.current.gridLayout.LocalToCell(transform.position);
            BoundsInt areaTemp = area;
            areaTemp.position = positionInt;
            Placed = true;
            GridBuildingSystem.current.TakeArea(areaTemp);
            gameController.wood -= necessaryAmount;

            
            if(index < 1)
            {
                OnBuild?.Invoke();
            }

            index++;


    }


    #endregion
}
