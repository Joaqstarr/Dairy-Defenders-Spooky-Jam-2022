using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    public int health = 200;
    public GameObject deathParticle;
    public Transform particleHolder;
    public AudioClip explode;
    AudioSource sfx;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();

    }
    public void Damage(int damageAmount)
    {
        sfx.clip = explode;
        sfx.Play();
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<ufoHover>().enabled = false;
        transform.GetChild(1).gameObject.SetActive(false);

        //can add death particle
        deathParticle = (GameObject)(Instantiate(deathParticle, particleHolder.transform.position, Quaternion.identity));
            Destroy(deathParticle, 2.8f);
            Destroy(gameObject, 5f);
    }
}
