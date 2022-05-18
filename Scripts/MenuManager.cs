using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button newGameButton, viewCharactersButton;
    private void Start()
    {
        newGameButton.onClick.AddListener(()=> NewGame());
        viewCharactersButton.onClick.AddListener(() => ViewCharacters());

    }

   
    public void NewGame()
    {
        SceneManager.LoadScene("Map");
    }

    public void ViewCharacters()
    {
        SceneManager.LoadScene("PlayerControls");
    }

    
}
