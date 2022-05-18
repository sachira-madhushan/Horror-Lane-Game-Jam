using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Button pauseButton,resumeButton,mainMenuButton,quiteButton;
    [SerializeField] private GameObject pauseWindow;

    void Start()
    {
        pauseWindow.SetActive(false);   
        pauseButton.onClick.AddListener(() => Pause());
        resumeButton.onClick.AddListener(() => Resume());
        mainMenuButton.onClick.AddListener(() => MainMenu());
        quiteButton.onClick.AddListener(()=>Application.Quit());
    }


    void Update()
    {

    }

    void Pause()
    {

        pauseWindow?.SetActive(true);
        Time.timeScale = 0;
    }

    void Resume()
    {

        pauseWindow?.SetActive(false);
        Time.timeScale = 1;
    }


    void MainMenu()
    {
        Destroy(pauseWindow);
        SceneManager.LoadScene("Menu");
    }
    
}
