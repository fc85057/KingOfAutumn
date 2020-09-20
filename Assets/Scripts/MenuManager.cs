using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField]
    private GameObject optionsMenu;

    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadOptions(bool optionsOn)
    {
        optionsMenu.SetActive(optionsOn);
    }

    public void Quit()
    {
        Application.Quit();
    }


    #region Options

    public void SetMusic(bool musicOn)
    {
        AudioManager.Instance.SetMusic(musicOn);
    }

    public void SetSfx(bool sfxOn)
    {
        AudioManager.Instance.SetSfx(sfxOn);
    }

    #endregion


}
