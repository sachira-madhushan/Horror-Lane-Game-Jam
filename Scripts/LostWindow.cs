using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LostWindow : MonoBehaviour
{

    [SerializeField] private Button playAgainButton, mainMenuButton,quiteButton;
    [SerializeField] private GameObject lostWindow;

    void Start()
    {
        playAgainButton.onClick.AddListener(() => RePlay());
        mainMenuButton.onClick.AddListener(() => MainMenu());
        quiteButton.onClick.AddListener(() => Application.Quit());
    }


    void Update()
    {

    }


    void RePlay()
    {
        
        lostWindow?.SetActive(false);
        SceneManager.LoadScene("DarkForest");
        Time.timeScale = 1;
    }


    void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
