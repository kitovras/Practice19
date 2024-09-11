using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject finishMenu;
    [SerializeField] Text finishCoinScope;
    private CoinScope coinScope;

    [SerializeField] UnityEvent itFinished;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerInput>(out var playerInput))
        {
            finishMenu.SetActive(true);
            itFinished.Invoke();
        }
    }
}
