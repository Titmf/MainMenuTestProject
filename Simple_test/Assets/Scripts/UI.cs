using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ticketCounter;
    public MoneyPocket _moneyPocket;
    
    void Awake()
    {
        _moneyPocket.OnMoneyChange += ChangeText;
    }
    private void ChangeText(int amount)
    {
        _ticketCounter.text = amount.ToString();
    }

    private void OnDestroy()
    {
        _moneyPocket.OnMoneyChange -= ChangeText;
    }
}