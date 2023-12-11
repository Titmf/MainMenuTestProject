using UnityEngine;
using UnityEngine.Purchasing;

public class MoneyPocket : MonoBehaviour
{
    [SerializeField] private int _moneyCount;

    public DailyEvent _dailyEvent;
    
    public delegate void MoneyChangedDelegate(int amount);
    public event MoneyChangedDelegate OnMoneyChange;

    private void Awake()
    {
        _dailyEvent.OnMoneyAdded += AddMoney;
    }

    private void Start()
    {
        OnMoneyChange?.Invoke(_moneyCount);
    }

    public void SpendMoney(int amount)
    {
        _moneyCount -= amount;
        OnMoneyChange?.Invoke(_moneyCount);
    }

    private void AddMoney(int amount)
    {
        _moneyCount += amount;
        OnMoneyChange?.Invoke(_moneyCount);
    }

    public void BuyTickets(Product product)
    {
        AddMoney((int) product.definition.payout.quantity);
    }
    
    private void OnDestroy()
    {
        _dailyEvent.OnMoneyAdded -= AddMoney;
    }
}