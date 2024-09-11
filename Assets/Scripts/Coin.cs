using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject coinParticleSystem;
    [SerializeField] private float coinValue = 1;

    private Renderer coinRenderer;
    private ParticleSystem particleSystem;
    private Collider2D collider2D;

    [SerializeField] private UnityEvent<float> coinRaised;

    private void Start()
    {
        coinRenderer = GetComponent<Renderer>();
        collider2D = gameObject.GetComponent<Collider2D>();
        particleSystem = coinParticleSystem.GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PlayerInput>(out _))
        {
            coinParticleSystem.SetActive(true);
            coinRenderer.enabled = false;
            collider2D.enabled = false;
            coinRaised.Invoke(coinValue);
            Destroy(gameObject, particleSystem.duration);
        }
    }
}
