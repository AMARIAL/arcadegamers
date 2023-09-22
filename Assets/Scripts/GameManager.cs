using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ST {get; private set;}
    void Awake()
    {
        ST = this;
    }
    
}
