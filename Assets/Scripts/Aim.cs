using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    private Rigidbody2D rb;
    
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
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(pos);
    }
}
