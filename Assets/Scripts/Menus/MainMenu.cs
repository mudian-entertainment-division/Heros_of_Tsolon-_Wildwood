using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public menuSelect MenuSelect = menuSelect.Play;
    public GameObject SettingsGO;


    private void Update()
    {
        //Go between menu panel and settings panel
        if (Settings.settingsOpen)
        {
            SettingsGO.SetActive(true);
        }
        else if (!Settings.settingsOpen)
        {
            SettingsGO.SetActive(false);
        }
    }
    public void ClickButton()
    {
        //Allows the use of buttons on the menu screen
        switch (MenuSelect)
        {
            case menuSelect.Play:
                break;
            case menuSelect.Settings:
                Settings.settingsOpen = !Settings.settingsOpen;
                break;
            case menuSelect.Quit:
                Application.Quit();
                break;
        }
    }
    public enum menuSelect
    {
        Play,
        Settings,
        Quit
    };
}
