using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtonsArray;
    private int _index = 1;
    private int _atLevel;
    
    private void Awake()
    {
        _atLevel = PlayerPrefs.GetInt("AtLevel", 2);
    }
    
    private void Start()
    {
        foreach (Button levelButton in _levelButtonsArray)
        {
            TextMeshProUGUI textMeshPro = levelButton.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = _index.ToString();
            
            int currentIndex = _index;
            if (_index < 29)
            {
                _levelButtonsArray[_index].onClick.AddListener(() => OpenNextLevel(currentIndex));
                _index++;   
            }
        }
        
        //player prefs atLevel should be load & set opened for i < atLevel, i++
    }

    public void OpenNextLevel (int numberCompletedLevel)
    {
        Image image = _levelButtonsArray[numberCompletedLevel+1].transform.Find("lock [Image]")?.GetComponent<Image>();
        
        if (image != null && image.gameObject.activeSelf)
        {
            image.gameObject.SetActive(false);
            _levelButtonsArray[numberCompletedLevel+1].interactable = true;
            _atLevel++;
        }
    }
}