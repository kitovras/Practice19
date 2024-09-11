using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject particleSystemDeath;
    [SerializeField] Transform transformDeathParticleSystem;
    [SerializeField] GameObject coin;

    public void Killing()
    {
        if (particleSystemDeath != null && transformDeathParticleSystem != null)
        {
            Instantiate(particleSystemDeath, transformDeathParticleSystem.position, transformDeathParticleSystem.rotation);
            if (coin != null)
            {
                Instantiate(coin, transformDeathParticleSystem.position, transformDeathParticleSystem.rotation);
            }
        }
        Destroy(gameObject);
    }
}
