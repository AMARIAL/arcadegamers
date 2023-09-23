using System.Collections;
using UnityEngine;

public class Points10 : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 0.3f;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(Coroutine());
    }

    private void Update()
    {
        _rb.velocity = Vector2.up*_speed;
    }

    private IEnumerator Coroutine ()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
}
