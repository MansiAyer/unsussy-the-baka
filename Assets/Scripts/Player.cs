using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.05f;
    public Vector2 move;
    SpriteRenderer mc;
    // Start is called before the first frame update
    void Start()
    {
        mc = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    void movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            move = Vector2.up;
            transform.Translate(move * speed * 1.5f);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move = Vector2.left;
            transform.Translate(move * speed);
            if (mc.flipX)
            {
                mc.flipX = false;
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move = Vector2.right;
            transform.Translate(move * speed);
            if (!mc.flipX)
            {
                mc.flipX = true;
            }
        }
   }
}
