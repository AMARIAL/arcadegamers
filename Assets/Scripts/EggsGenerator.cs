using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsGenerator : MonoBehaviour
{
    public static EggsGenerator ST {get; private set;}
    
    [SerializeField] private GameObject egg;
    public bool isSpawn = true;
    public float coolDown = 1.0f;

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
