using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun ST  {get; private set;}
    public bool isCanShoot;
    public float coolDown;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletsParent;
    [SerializeField]
    private Transform bulletSpawnPos;

    [SerializeField] private Transform aim;

    
    private void Awake()
    {
        ST = this;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        isCanShoot = false;
        GameObject spawnBullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation);
        spawnBullet.transform.parent = bulletsParent.transform;
        spawnBullet.GetComponent<Bullet>().Aim = aim;
        StartCoroutine(Coroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isCanShoot)
            Shoot();
    }

    private IEnumerator Coroutine ()
    {
        yield return new WaitForSeconds(coolDown);
        isCanShoot = true;
        yield break;
    }
}
