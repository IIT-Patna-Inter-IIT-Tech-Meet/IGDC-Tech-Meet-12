using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public countkeys cc;
    public string curscene;
    public Transform playercheck;
    public LayerMask playerlayer;
    public GameObject errorc;
    bool collide;
    public float s1;
    public float s2;
    public float s3;
    public int num;
    public string n1;
    public string n2;
    public string n3;
    bool iswon = false;
    bool isupdated = false;
    public int totalKeyss = 1;
    public float period = 1f;
    private float nextActionTime = 0.0f;
    public float starttime;
    public TMP_Text t1;
    public TMP_Text t2;
    public GameObject wonui;
    public TMP_Text text;
    public AudioSource source;
    string pp;
    void Start()
    {
        curscene = SceneManager.GetActiveScene().name;
        pp = "/"+curscene + ".json";
        string path1 = File.ReadAllText(Application.persistentDataPath + "/playernum.json");
        select playerdata1 = JsonUtility.FromJson<select>(path1);
        num = playerdata1.num;
        string path2 = File.ReadAllText(Application.persistentDataPath + "/player.json");
        numplayer playerdata2 = JsonUtility.FromJson<numplayer>(path2);
        n1 = playerdata2.name1;
        n2 = playerdata2.name2;
        n3 = playerdata2.name3;
        starttime = Time.time;
        string path = File.ReadAllText(Application.persistentDataPath + pp);
        levelscore playerdata = JsonUtility.FromJson<levelscore>(path);
        //System.IO.File.WriteAllText(path, gamed);
        //string gamed = System.IO.File.ReadAllText(path);

        s1 = playerdata.s1;
        s2 = playerdata.s2;
        s3 = playerdata.s3;

        text = text.GetComponent<TMP_Text>();
        text.text = "0";
        //nextActionTime = 0-Time.time;
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - starttime;
        if (t > nextActionTime && !iswon)
        {
            nextActionTime += period;
            t += 1;

            //i++;

        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            tt.SetActive(false);
            Time.timeScale = 1f;
            nextActionTime = 0;
        }*/
        text.text = t.ToString();
        text.text = t.ToString();

        collide = Physics2D.OverlapCapsule(playercheck.position, new Vector2(3f, 3f), CapsuleDirection2D.Horizontal, 0, playerlayer);
        if (collide)
        {

            if (isupdated == false)
            {

                if (cc.totalkeys < totalKeyss)
                {
                    Time.timeScale = 0;
                    errorc.SetActive(true);
                }
                else
                {
                    iswon = true;
                    source.Play();
                    won(t,pp);

                }
                isupdated = true;
                


            }


        }
        else
        {
            isupdated = false;


        }
    }

    public void won(float t, string pp)
    {
        if (iswon)
        {
            

            if (num == 1)
            {
                //levelscore playerdata = new levelscore();
                levelscore playerdata = new levelscore();
                if (s1 != 0)
                {
                    if (t < s1)
                    {
                        s1 = t;
                    }

                }
                else
                {
                    s1 = t;
                }
                playerdata.s1 = s1;
                playerdata.s2 = s2;
                playerdata.s3 = s3;

                string gamed = JsonUtility.ToJson(playerdata, true);
                string path = Application.persistentDataPath + pp;
                //n3.SetActive(true);
                Debug.Log(path);

                File.WriteAllText(path, gamed);
            }
            if (num == 2)
            {
                levelscore playerdata1 = new levelscore();
                if (s2 != 0)
                {
                    if (t < s2)
                    {
                        s2 = t;
                    }

                }
                else
                {
                    s2 = t;
                }
                playerdata1.s1 = s1;
                playerdata1.s2 = s2;
                playerdata1.s3 = s3;

                string gamed = JsonUtility.ToJson(playerdata1, true);
                string path = Application.persistentDataPath + pp;
                //n3.SetActive(true);
                Debug.Log(path);

                File.WriteAllText(path, gamed);
            }
            if (num == 3)
            {

                levelscore playerdata2 = new levelscore();
                playerdata2.s1 = s1;
                playerdata2.s2 = s2;
                if (s3 != 0)
                {
                    if (t < s3)
                    {
                        s3 = t;
                    }

                }
                else
                {
                    s3 = t;
                }
                playerdata2.s3 = s3;

                string gamed = JsonUtility.ToJson(playerdata2, true);
                string path = Application.persistentDataPath + pp;
                //n3.SetActive(true);
                Debug.Log(path);

                File.WriteAllText(path, gamed);

            }
            string path1 = File.ReadAllText(Application.persistentDataPath + pp);
            levelscore player = JsonUtility.FromJson<levelscore>(path1);
            //System.IO.File.WriteAllText(path, gamed);
            //string gamed = System.IO.File.ReadAllText(path);

            s1 = player.s1;
            s2 = player.s2;
            s3 = player.s3;


            t2.text = s1 + "\n\n" + s2 + "\n\n" + s3;
            t1.text = n1 + "\n\n" + n2 + "\n\n" + n3;
            wonui.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
