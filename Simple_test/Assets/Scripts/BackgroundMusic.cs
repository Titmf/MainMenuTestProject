using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;

    private bool _musicMuted = false;
   

    void Start()
    {
        if (!PlayerPrefs.HasKey("_musicMuted"))
        {
            PlayerPrefs.SetInt("_musicMuted", 0);
            Load();
        }
        else
        {
            Load();
        }

        _backgroundMusic.volume = 0;
    }

    public void OnButtonPress()
    {
        if (_musicMuted == false)
        {
            _musicMuted = true;
            _backgroundMusic.volume = 0;
        }

        else
        {
            _musicMuted = false;
            _backgroundMusic.volume = 1;
        }
        
        Save();
    }

    private void Load()
    {
        _musicMuted = PlayerPrefs.GetInt("_musicMuted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("_musicMuted", _musicMuted ? 1 : 0);
    }
}