using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainButton : MonoBehaviour
{
    public void start()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PlayerSelect");
    }
    public void tutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("tutorial");
    }
    public void quit()
    {
        Application.Quit();
    }
}
