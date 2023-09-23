using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager ST {get; private set;}
    
    [SerializeField] private TextMeshProUGUI  textMeshPro;
    [SerializeField] private int points;
    
    void Awake()
    {
        ST = this;
    }
    
    public void AddPoints (int val)
    {
        points +=val;
        textMeshPro.text = points.ToString();
    }
    
    
}
