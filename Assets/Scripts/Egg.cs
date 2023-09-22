using UnityEngine;

public class Egg : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
        if(transform.position.y < -10)
            Destroy(gameObject);
    }
}
