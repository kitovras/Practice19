using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelBomb : MonoBehaviour
{
    [SerializeField] float bumValue;
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject particleSystemBomb;
    [SerializeField] float timeLiveBomb;
    [SerializeField] float bombForce;

    private Renderer renderer;
    private ParticleSystem particleSystem;
    private Rigidbody2D rb;
    private Collider2D collider2D;
    private PointEffector2D eff;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody2D>();
        particleSystem = particleSystemBomb.GetComponent<ParticleSystem>();
        collider2D = GetComponent<Collider2D>();
        eff = bomb.GetComponent<PointEffector2D>();
        eff.forceMagnitude = bombForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > bumValue)
        {
            Boom();
        }
    }

    public void Boom()
    {
        bomb.SetActive(true);
        StartCoroutine(DeleteEffector());
        renderer.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        collider2D.isTrigger = true;
        particleSystemBomb.SetActive(true);
        Destroy(gameObject, particleSystem.duration);
    }

    IEnumerator DeleteEffector()
    {
        yield return new WaitForSeconds(timeLiveBomb);
        bomb.SetActive(false);
    }
}
