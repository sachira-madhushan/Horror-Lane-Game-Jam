using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioHandler : MonoBehaviour
{

    [SerializeField] private GameObject pauseWindow, lostWindow, winWindow,pauseButtonWindow;
    [SerializeField] private AudioSource backgroundSound, pauseSound, lostSound, winSound;
    void Start()
    {

    }


    void Update()
    {
        if ((pauseWindow.active == true || winWindow.active == true || lostWindow.active == true) && (backgroundSound.isPlaying==true))
        {
            backgroundSound.Pause();
        }
        else if ((pauseWindow.active == false && winWindow.active == false && lostWindow.active == false)&&(backgroundSound.isPlaying==false))
        {
            backgroundSound.Play();
            pauseSound.Stop();
            winSound.Stop();
            lostSound.Stop();
        }

        if (pauseWindow.active == true && pauseSound.isPlaying==false)
        {
            pauseSound.Play();
        }
        if (lostWindow.active == true && lostSound.isPlaying == false)
        {
            pauseButtonWindow.SetActive(false);
            lostSound.Play();
        }
        if (winWindow.active == true && winSound.isPlaying == false)
        {
            winSound.Play();
        }
    }
}
