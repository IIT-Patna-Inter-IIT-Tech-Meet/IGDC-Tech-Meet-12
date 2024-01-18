using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countkeys : MonoBehaviour
{
    // Start is called before the first frame update
    public float totalkeys = 0;
    public TextMeshProUGUI keymesh;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        keymesh.text = totalkeys.ToString();
    }
}
