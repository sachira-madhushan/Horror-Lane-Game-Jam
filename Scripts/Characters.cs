using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Characters : MonoBehaviour
{
    [SerializeField]
    private Button backButton;


    void Start()
    {
        backButton.onClick.AddListener(() => goBack());
        

    }
    void Update()
    {

    }
    void goBack()
    {
        SceneManager.LoadScene("Menu");
    }

}
