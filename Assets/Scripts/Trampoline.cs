using System;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public static Trampoline ST {get; private set;}

    [HideInInspector] public Rigidbody2D rigidboby;
    
    [Header("Параметры")]
    [SerializeField] public float speed = 7.0f;
    [SerializeField] public float minPos = -2.88f;
    [SerializeField] public float maxPos = 0.91f;
    void Awake()
    {
        ST = this;
    }
    void Start()
    {
        rigidboby = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        Vector2 direction = Vector2.zero;
        
        if (Input.GetKey(KeyCode.A) && transform.position.x > minPos)
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < maxPos)
        {
            direction.x = 1;
            
        }
        
        direction *= speed;
        
        rigidboby.velocity = direction;
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Egg"))
        {
            Audio.ST.PlaySound(Sounds.jump);
        }
    }
    
}
