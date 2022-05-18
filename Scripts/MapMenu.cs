using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MapMenu : MonoBehaviour
{
    [SerializeField]
    private Button backButton,darkForest;
    

    void Start()
    {
        backButton.onClick.AddListener(() => goBack());
        darkForest.onClick.AddListener(() => LoadDarkForest());
        
    }
    void Update()
    {
        
    }
    void goBack()
    {
        SceneManager.LoadScene("Menu");
    }
    void LoadDarkForest()
    {
        SceneManager.LoadScene("DarkForest");
    }
}
