using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager ST {get; private set;}
    
    [SerializeField] private Image timerImage;
    [SerializeField] private TextMeshProUGUI  pointsTmp;
    [SerializeField] private TextMeshProUGUI  countTmp;
    [SerializeField] private TextMeshProUGUI  percentTmp;
    [SerializeField] private TextMeshProUGUI  winTmp;
    [SerializeField] private int points;
    [SerializeField] private int eggs = 0;
    [SerializeField] private int hited = 0;
    
    [SerializeField] private int maxGameTimeSeconds = 180;
    [SerializeField] private float currentGameTime;
    [SerializeField] private GameObject winPanel;

    public bool isGameOver = false;
    public bool isTimerStarted = false;
    
    void Awake()
    {
        ST = this;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 25;
    }

    private void Start()
    {
        Time.timeScale = 1;
        currentGameTime = maxGameTimeSeconds;
        winTmp = GameObject.Find("WinText").GetComponent<TextMeshProUGUI>();
        winPanel.SetActive(false);
    }

    public void AddPoints (int val)
    {
        if(val < 0 && points == 0)
            return;
        points +=val;
        pointsTmp.text = points.ToString();
    }
    
    public void AddEgg (bool flag)
    {
        if (flag)
            hited++;
        else
        {
            eggs++;
        }

        countTmp.text = hited + "/" + eggs;
        percentTmp.text = Math.Round((float)hited / (float)eggs * 100) + "%";
    }

    private void Update()
    {
        Timer();
        
        if (Input.GetKeyUp(KeyCode.M))
        {
            Audio.ST.MusicOnOff(!Audio.ST.MusicOn);
        }
        else if (Input.GetKeyUp(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Audio.ST.MusicOnOff(false);
                Time.timeScale = 0;
            }
            else
            {
                Audio.ST.MusicOnOff(true);
                Time.timeScale = 1;
            }
                
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Timer()
    {
        currentGameTime -= Time.deltaTime;
        
        timerImage.fillAmount =  currentGameTime / maxGameTimeSeconds;

        if (currentGameTime <= 10 && !isTimerStarted)
        {
            isTimerStarted = true;
            Audio.ST.PlaySound(Sounds.timer);
        }
        
        if (currentGameTime <= 0 && !isGameOver)
        {
            isGameOver = true;
            Audio.ST.StopSound();
            Audio.ST.PlayMusic(Music.end);
            Time.timeScale = 0;
            winPanel.SetActive(true);
            winTmp.text = "Конец игры!" + "\n" +
                          "Очки: " + points + "\n" +
                          "Попаданий: " + hited + "\n" +
                          "Всего яиц: " + eggs + "\n" +
                          "Процент попаданий: " + Math.Round((float) hited / (float) eggs * 100) + "%\n\n" +
                          "для перезапуска нажмите Esc" + "\n" + 
                          "для выхода Alt+F4";
        }
    }
}
