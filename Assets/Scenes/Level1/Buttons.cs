using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject errorcan;
    public void errorclick()
    {
        Time.timeScale = 1;
        errorcan.SetActive(false);
    }
}
