using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 oldPos;
    
    public static Aim ST  {get; private set;} // Audio.ST (Singltone)
    private void Awake()
    {
        ST = this;
    }
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (oldPos != pos)
        {
            Vector2 aimPos = (Vector2)transform.position + pos - oldPos;
        
            rb.MovePosition(aimPos);
        
            oldPos = pos;
        }

    }
}
