using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerScript : MonoBehaviour
{
    public AudioSource MenuMusic;
    public AudioSource Click;

    public bool soundIsMuted = false;

    public Button MuteButton;

    public Sprite Muted;
    public Sprite Unmuted;

    void Start()
    {
        MenuMusic.Play();
    }

    public void GoToLevel()
    {
        Application.LoadLevel("Game scene");
        Click.Play();
    }

    public void ExitGame()
    {
        Click.Play();
        Application.Quit();
    }

    public void MuteMusic()
    {
        if (soundIsMuted)
        {
            MenuMusic.UnPause();
            Click.mute = false;
            Click.Play();
            soundIsMuted = false;

            MuteButton.image.sprite = Unmuted;
        }
        else
        {
            MenuMusic.Pause();
            Click.mute = true;
            soundIsMuted = true;

            MuteButton.image.sprite = Muted;
        }
    }
}
