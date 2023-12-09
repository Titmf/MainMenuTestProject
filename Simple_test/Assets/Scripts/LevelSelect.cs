using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public Button[] LevelButtonsArray;
    private int _index = 1;
    private int AtLevel;
    
    private void Awake()
    {
        AtLevel = PlayerPrefs.GetInt("AtLevel", 2);
    }
    
    private void Start()
    {
        foreach (Button levelButton in LevelButtonsArray)
        {
            TextMeshProUGUI textMeshPro = levelButton.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = _index.ToString();
            
            int currentIndex = _index;
            if (_index < 29)
            {
                LevelButtonsArray[_index].onClick.AddListener(() => OpenNextLevel(currentIndex));
                _index++;   
            }
        }
    }

    public void OpenNextLevel (int numberCompletedLevel)
    {
        Image image = LevelButtonsArray[numberCompletedLevel+1].transform.Find("lock [Image]")?.GetComponent<Image>();
        
        if (image != null && image.gameObject.activeSelf)
        {
            image.gameObject.SetActive(false);
            LevelButtonsArray[numberCompletedLevel+1].interactable = true;
            AtLevel++;
        }
    }
}