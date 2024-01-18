using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class keys : MonoBehaviour
{
    
    
    
    public Transform playercheck;
    public LayerMask playerlayer;
    public countkeys cc;
    bool isupdated = false;
    public GameObject curKey;
    public AudioSource source;


    bool collide;

    void start()
    {
        
        
    }
    void FixedUpdate()
    {

        
        collide = Physics2D.OverlapCapsule(playercheck.position, new Vector2(3f, 3f), CapsuleDirection2D.Horizontal, 0, playerlayer);
        if (collide)
        {
            
            if (isupdated == false)
            {
                source.Play();

                cc.totalkeys++;
                isupdated = true;
                curKey.SetActive(false);
                

            }

            
        }
        else
        {
            isupdated = false;
            

        }

    }

}
