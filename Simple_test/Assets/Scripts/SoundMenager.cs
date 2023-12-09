using UnityEngine;

public class SoundMenager : MonoBehaviour
{
    private bool _muted = false;
    void Start()
    {
        if (!PlayerPrefs.HasKey("_muted"))
        {
            PlayerPrefs.SetInt("_muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        AudioListener.pause = _muted;
    }

    public void OnButtonPress()
    {
        if (_muted == false)
        {
            _muted = true;
            AudioListener.pause = true;
        }

        else
        {
            _muted = false;
            AudioListener.pause = false;
        }
        
        Save();
    }

    private void Load()
    {
        _muted = PlayerPrefs.GetInt("_muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("_muted", _muted ? 1 : 0);
    }
}