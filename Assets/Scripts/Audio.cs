using UnityEngine;
public enum Sounds
{
    gun,
    jump,
    egg,
    timer
}
public enum Music
{
    game,
    end
}
public class Audio : MonoBehaviour
{
    public static Audio ST  {get; private set;}
    
    public bool MusicOn = true;

    public AudioSource musicAudio;
    
    [SerializeField] private AudioSource gun;
    [SerializeField] private AudioSource jump;
    [SerializeField] private AudioSource egg;
    [SerializeField] private AudioSource timer;


    [SerializeField] private AudioClip game;
    [SerializeField] private AudioClip end;

    private void Awake()
    {
        ST = this;
        musicAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        if (!MusicOn)
        {
            musicAudio.Stop();
        }
    }
    
    public void MusicOnOff(bool isOn = true)
    {
        MusicOn = isOn;
        
        if (MusicOn)
            musicAudio.Play();
        else
            musicAudio.Stop();
    }
    public void PlayMusic(Music music)
    {
        switch (music)
        {
            case Music.game: musicAudio.clip = game; break;
            case Music.end: musicAudio.clip = end;
                musicAudio.loop = false; break;
        }
        if(MusicOn)
            musicAudio.Play();
    }

    public void StopSound()
    {
        timer.Stop();
    }

    public void PlaySound(Sounds sound)
    {
        switch (sound)
        {
            case Sounds.gun: gun.Play(); break;
            case Sounds.jump: jump.Play(); break;
            case Sounds.egg: egg.Play(); break;
            case Sounds.timer: timer.Play();break;
        }
    }
}
