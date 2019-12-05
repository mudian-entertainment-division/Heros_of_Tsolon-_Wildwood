using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    private GameObject _pauseMenu;
    // Update is called once per frame
    void Start()
    {
        _pauseMenu = GameObject.FindGameObjectWithTag("Pausemenu");
        isPaused = false;//not pasued 
        Time.timeScale = 1;//start time
        _pauseMenu.SetActive(false);//hide pause menu

    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))//press escape
        {
            TogglePause();//runs pause function
        }
    }

    public void TogglePause()
    {
        if (isPaused)//is true if it is active
        {
            _pauseMenu.SetActive(false);//show pause menu
            isPaused = true;//not pasued 
            Time.timeScale = 0;//start time
        }
        else//is false if it is active
        {
            _pauseMenu.SetActive(true);//hide pause menu
            isPaused = false;//we are pasued
            Time.timeScale = 1;//stop time
        }
    }
}
