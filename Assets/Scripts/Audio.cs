using UnityEngine;
public enum Sounds
{
    intro,
    box,
    start,
    take,
    hit,
    speed
}
public enum Music
{
    metal,
    game
}
public class Audio : MonoBehaviour
{
    public static Audio ST  {get; private set;} // Audio.ST (Singltone)
    
    public bool MusicOn = true;
    public bool SoundOn = true;
    
    public AudioSource musicAudio;
    
    [SerializeField] private AudioSource intro;
    [SerializeField] private AudioSource box;
    [SerializeField] private AudioSource start;
    [SerializeField] private AudioSource take;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource speed;

    
    [SerializeField] private AudioClip metal;
    [SerializeField] private AudioClip game;
    
    private void Awake()
    {
        ST = this;
        musicAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("MUSIC") && PlayerPrefs.GetString("MUSIC") == "OFF")
            MusicOn = false;
        if (PlayerPrefs.HasKey("SOUND") && PlayerPrefs.GetString("SOUND") == "OFF")
            SoundOn = false;
        
        if (!MusicOn)
        {
            musicAudio.Stop();
        }
    }
    
    public void SoundOnOff(bool isOn = true)
    {
        SoundOn = isOn;
        PlayerPrefs.SetString("SOUND", SoundOn ? "ON" : "OFF");
        PlayerPrefs.Save();
    }
    
    public void MusicOnOff(bool isOn = true)
    {
        MusicOn = isOn;
        
        PlayerPrefs.SetString("MUSIC", MusicOn ? "ON" : "OFF");
        PlayerPrefs.Save();
        
        if (MusicOn)
            musicAudio.Play();
        else
            musicAudio.Stop();
    }
    public void PlayMusic(Music music)
    {
        switch (music)
        {
            case Music.metal: musicAudio.clip = metal; break;
            case Music.game: musicAudio.clip = game; break;
        }
        if(MusicOn)
            musicAudio.Play();
    }
    public void PlaySound(Sounds sound)
    {
        if (!SoundOn) 
            return;
        
        switch (sound)
        {
            case Sounds.intro: intro.Play(); break;
            case Sounds.box: box.Play(); break;
            case Sounds.start: start.Play(); break;
            case Sounds.take: take.Play(); break;
            case Sounds.hit: hit.Play(); break;
            case Sounds.speed: speed.Play(); break;
        }
    }
}
