using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{
    public string curscene;
    public GameObject pause;
    private void Start()
    {
        curscene = SceneManager.GetActiveScene().name;
    }
    public void main()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("mainmenu");
    }
    public void retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(curscene);
    }
    public void resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1;

    }
}
