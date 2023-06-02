using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    private GameController _gameController;

    public TextMeshProUGUI primaryResourceValueElem;

    void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        primaryResourceValueElem.text = _gameController.wood.ToString();
    }
}
