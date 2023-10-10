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
        //rb = GetComponent<Rigidbody2D>();
    }

    public void Shoot()
    {
        isCanShoot = false;
        GameObject spawnBullet = Instantiate(bullet, bulletSpawnPos.position, bullet.transform.rotation);
        spawnBullet.transform.parent = bulletsParent.transform;
        spawnBullet.GetComponent<Bullet>().Aim = aim;
        Audio.ST.PlaySound(Sounds.gun);
        StartCoroutine(Coroutine());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isCanShoot)
            Shoot();
        
        transform.LookAt(new Vector3(aim.position.x, aim.position.y,1000), Vector3.back);
    }

    private IEnumerator Coroutine ()
    {
        yield return new WaitForSeconds(coolDown);
        isCanShoot = true;
        yield break;
    }
}
