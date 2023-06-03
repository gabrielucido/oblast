using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestController : MonoBehaviour
{
    [SerializeField] private GameObject questPanelDescription;
    [SerializeField] private GameObject questPanelDescription_2;
    [SerializeField] private GameObject questPanelDescription_3;
    [SerializeField] public string description;
    [SerializeField] public string description_2;
    [SerializeField] public string description_3;

    private bool Q1isActive;
    private bool Q2isActive;
    private bool Q3isActive;    


    public TMP_Text descriptionText;
    public TMP_Text descriptionText_2;
    public TMP_Text descriptionText_3;
    public void Start()
    {
        descriptionText.text = description;
        descriptionText_2.text = description_2;
        descriptionText_3.text = description_3;
        Q1isActive = false;
        Q2isActive = false;
        Q3isActive = false;
    }
    public void OpenQuestDescription_1()
    {
        questPanelDescription.SetActive(true);
        questPanelDescription_2.SetActive(false);
        Q1isActive = true;
    }

    public void OpenQuestDescription_2()
    {
        questPanelDescription_2.SetActive(true);
        questPanelDescription.SetActive(false);
        Q2isActive = true;
    }

    public void OpenQuestDescription_3()
    {
        questPanelDescription_3.SetActive(true);
        questPanelDescription.SetActive(false);
        Q3isActive = true;
    }

    public void CloseQuestDescripition()
    {
        if(Q1isActive == true)
        {
            questPanelDescription.SetActive(false);
        }
        if(Q2isActive == true)
        {
            questPanelDescription_2.SetActive(false);
        }

        if(Q3isActive == true)
        {
            questPanelDescription_3.SetActive(false);
        }
            
       
    }

}
