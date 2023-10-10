using UnityEngine;

public class Egg : MonoBehaviour
{

    private Rigidbody2D rb;
    private float rand;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rand = Random.Range(-100.0f, -300.0f);
        GameManager.ST.AddEgg(false);
    }
    
    void Update()
    {
        rb.angularVelocity = rand;
        if(transform.position.y < -10)
            Destroy(gameObject);
    }

    public void Hit(int val)
    {
        GameManager.ST.AddPoints(val);
        if (val > 0)
        {
            GameManager.ST.AddEgg(true);
            EggsGenerator.ST.Blood(transform.position,true);
        }
            
        else 
            EggsGenerator.ST.Blood(transform.position,false);
        Audio.ST.PlaySound(Sounds.egg);
        Destroy(gameObject);
    }
    
}
