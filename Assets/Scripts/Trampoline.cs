using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public static Trampoline ST {get; private set;}

    [HideInInspector] public Rigidbody2D rigidboby;
    
    [Header("Параметры")]
    [SerializeField] public float speed = 7.0f;
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
        
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
            
        }
        
        direction *= speed;
        
        rigidboby.velocity = direction;
        
    }
}
