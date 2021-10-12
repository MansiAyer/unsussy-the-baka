using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class lvl1_player : MonoBehaviour
{
    public float speed = 0.05f;
    public Vector2 forward;
    bool activemc;
    List<GameObject> actpath = new List<GameObject>();
    List<string> failtexts = new List<string>() {"You hit a pop-up and your device data was corrupted", "You accidentally clicked a pop-up and it deleted all your files","You clicked a pop-up that locked you out of your device","Popups bad"};

    public Vector2 mcplace;
    SpriteRenderer mclvl1;
    Rigidbody2D rblvl1;
    public GameObject rip;
    public GameObject pathpiece;
    // Start is called before the first frame update
    void Start()
    {
        mclvl1 = GetComponent<SpriteRenderer>();
        rblvl1 = GetComponent<Rigidbody2D>();
        activemc = true;
        mcplace = transform.position;

        //int x = (int)mcplace.x;
        //int y = (int)mcplace.y;
        int x = 0;
        int y = 0;
        GameObject g = (GameObject)Instantiate(pathpiece, new Vector2(x, y), Quaternion.identity);
        actpath.Insert(0, g);
        GameObject h = (GameObject)Instantiate(pathpiece, new Vector2(x+22, y), Quaternion.identity);
        actpath.Insert(0, h);
    }

    // Update is called once per frame
    void Update()
    {
        moveornot();
        movement();
        mcplace = transform.position;
        if ((mcplace.x > 12) && (mcplace.x + 5 > actpath[0].transform.position.x+6))
        {
            setpath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            Time.timeScale = 0;
            activemc = false;

        }
        
    }
    void moveornot()
    {
        if (activemc)
        {
            //mcplace += ;
            transform.Translate(Vector2.right * speed * 2.5f);
        }
        else
        {
            levelfail();
        }
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if (mcplace.y<4)
            {
                Vector2 move = Vector2.up;
                transform.Translate(move * speed * 8);
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //Vector2 move = Vector2.left;
            //transform.Translate(move * speed);
            //if (mclvl1.flipX)
            //{
            //    mclvl1.flipX = false;
            //}
        }
    }

    void levelfail()
    {
        GameObject failmsg = rip.transform.GetChild(1).gameObject;
        Text failtext = failmsg.GetComponent<Text>();
        int randindex = (int)Random.Range(0, failtexts.Count - 1);
        failtext.text = failtexts[randindex];
        rip.SetActive(true);
    }

    void setpath()
    {
        if (actpath.Count < 5)
        {
            actpath.RemoveAll(s => s == null);
            int x = (int)actpath[0].transform.position.x + 22;
            int y = (int)actpath[0].transform.position.y;
            GameObject g = (GameObject)Instantiate(pathpiece, new Vector2(x, y), Quaternion.identity);
            actpath.Insert(0, g);
            //actpath.RemoveAt(actpath.Count - 1);
            Destroy(actpath[actpath.Count - 1]);
            //Debug.Log(actpath.Count);
        }
        
    }

}
