using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScope : MonoBehaviour
{
    [SerializeField] Text coinScopeText;
    [SerializeField] Text finishCoinScopeText;
    private float currentCoinScope = 0;

    private void Start()
    {
        AddCoins(0);
    }

    public void AddCoins(float coins)
    {
        currentCoinScope += coins;
        UpdateCoinScope();
    }

    private void UpdateCoinScope()
    {
        coinScopeText.text = currentCoinScope.ToString();
        finishCoinScopeText.text = currentCoinScope.ToString();
    }
}
