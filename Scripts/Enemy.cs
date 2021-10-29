using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionFX;
    private void OnParticleCollision(GameObject other)
    {
        FindObjectOfType<Scoreboard>().AddScore();
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
