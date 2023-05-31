using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CountYears : MonoBehaviour
{
    public int currentYear = 20000;
    public TextMeshProUGUI textMeshProText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        currentYear--;
        textMeshProText.text = currentYear.ToString();
    }
}
