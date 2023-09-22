using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun ST  {get; private set;}
    public bool isCanShoot;
    public float coolDown;
    private Rigidbody2D rb;
    [SerializeField] private GameObject egg;

    
    void Awake()
    {
        ST = this;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        StartCoroutine(Coroutine("CoolDown"));
    }

    public void Shoot()
    {
        
    }

    private void Update()
    {
    }

    private IEnumerator Coroutine (string name)
    {
        switch (name)
        {
            case "CoolDown":
                while (!isCanShoot)
                {
                    yield return new WaitForSeconds(coolDown);
                    isCanShoot = true;
                }
                break;
        }
        yield break;
    }
}
