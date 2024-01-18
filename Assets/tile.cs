using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tile : MonoBehaviour
{
    public int count;
    public TextMeshPro _count;
    bool isupdated = false;
    public Transform playercheck;
    public LayerMask playerlayer;
    public SpriteRenderer spriteRenderer;
    bool collide;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    public GameObject lostScreen;
    bool isdead = false;
    public AudioSource source;


    void start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        _count.text = count.ToString();
    }
    void FixedUpdate()
    {

        _count.text = count.ToString();
        collide = Physics2D.OverlapCapsule(playercheck.position, new Vector2(2.5f, 2.5f), CapsuleDirection2D.Horizontal, 0, playerlayer);
        if (collide)
        {
            
            
            spriteRenderer.color = (Color)(new Color32(255, 203, 251, 255));
            if (isupdated == false)
            {
                source.Play();
                if (count == 0)
                {
                    
                    isdead = true;
                    Debug.Log("death");
                    death();

                }
                count--;


                isupdated = true;
            }
            
            Debug.Log("collided");
        }
        else
        {
            
            isupdated = false;
            
            spriteRenderer.color = (Color)(new Color32(255, 255, 255, 255));
            if (count == 5)
            {
                spriteRenderer.sprite = s5;
            }
            if (count == 4)
            {
                spriteRenderer.sprite = s1;
            }
            if (count == 3)
            {
                spriteRenderer.sprite = s2;
            }
            if (count == 2)
            {
                spriteRenderer.sprite = s3;
            }
            if (count == 1)
            {
                spriteRenderer.sprite = s4;
            }
            if (count == 0)
            {
                spriteRenderer.sprite = s6;
            }

        }
    }
    public void death()
    {
        Time.timeScale = 0;
        lostScreen.SetActive(true);
    }

}
