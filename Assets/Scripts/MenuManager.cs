using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject OptionsMenu;
    [SerializeField] private GameObject PauseMenu;

    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
      MainMenu.SetActive(false);
      OptionsMenu.SetActive(true);
      PauseMenu.SetActive(false);
    }
    
    public void CloseOptions()
    {
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void CloseOptionsGame()
    {
      OptionsMenu.SetActive(false);
      PauseMenu.SetActive(true);
      
    }
   public void Exit()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && scene.name != "MainMenu")
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ReturnPlay()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
}
