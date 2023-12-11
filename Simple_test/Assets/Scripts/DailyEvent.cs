using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyEvent : MonoBehaviour
{
    [SerializeField] private List<Button> _buttons;
    
    private DateTime _lastRewardTime;
    private int _dayCount;
    
    public delegate void MoneyAddedDelegate(int amount);
    public event MoneyAddedDelegate OnMoneyAdded;
    
    void Start()
    {
        string lastRewardTimeString = PlayerPrefs.GetString("LastRewardTime", string.Empty);
        if (!string.IsNullOrEmpty(lastRewardTimeString))
        {
            _lastRewardTime = DateTime.Parse(lastRewardTimeString);
        }
        else
        {
            _lastRewardTime = DateTime.Now;
        }

        if (IsNextDay())
        {
            _dayCount++;
            UnlockNextRewardButton();
        }
    }
    private void UnlockNextRewardButton()
    {
        _buttons[_dayCount].interactable = true;
    }

    public void GetReward(int rewardCount)
    {
        OnMoneyAdded?.Invoke(rewardCount);
        
        _lastRewardTime = DateTime.Now;
        PlayerPrefs.SetString("LastRewardTime", _lastRewardTime.ToString());
        
        _buttons[_dayCount].interactable = false;
    }
    
    private bool IsNextDay()
    {
        DateTime currentDate = DateTime.Now;
        return currentDate.Date > _lastRewardTime.Date;
    }
}