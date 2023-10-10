using UnityEngine;

public class Hare : MonoBehaviour
{

    [HideInInspector] public Animator animator;
    [HideInInspector] public Rigidbody2D rigidboby;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidboby = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(rigidboby.velocity.x));
    }
}
