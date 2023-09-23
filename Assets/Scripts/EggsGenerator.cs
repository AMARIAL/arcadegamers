using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsGenerator : MonoBehaviour
{
    public static EggsGenerator ST {get; private set;}
    
    [SerializeField] private GameObject egg;
    [SerializeField] private GameObject blood;
    [SerializeField] private GameObject points10;
    [SerializeField] private GameObject points1;
    public bool isSpawn = true;
    public float coolDown;
    public float coolDownMin = 1.0f;
    public float coolDownMax = 2.0f;
    void Awake()
    {
        ST = this;
    }
    void Start()
    {
        StartCoroutine(Coroutine("Spawn"));
    }

    private void Spawn()
    {
        Instantiate(egg, transform.position, Quaternion.identity,transform);
        coolDown = Random.Range(coolDownMin, coolDownMax);
    }
    
    public void Blood(Vector2 pos, bool flag)
    {
        Instantiate(blood, pos, Quaternion.identity, transform);
        if(flag)
            Instantiate(points10, pos, Quaternion.identity, transform);
        else
        {
            Instantiate(points1, pos, Quaternion.identity, transform);
        }
    }
    
    private IEnumerator Coroutine (string name)
    {
        switch (name)
        {
            case "Spawn":
                while (isSpawn)
                {
                    yield return new WaitForSeconds(coolDown);
                    Spawn();
                }
                break;
        }
        yield break;
    }
}
