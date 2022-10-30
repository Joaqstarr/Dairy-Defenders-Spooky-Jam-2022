using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class rayCastShoot : MonoBehaviour
{
    public bool isShooting;
    public float recoil = 1.8f;
    public int gunDamage = 100;
    public float fireRate = 0.25f;
    public float weaponRange = 100f;
    public float hitforce = 100f;
    public Transform gunEnd;
    [SerializeField]
    private Camera fpsCamera;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.3f);
    private LineRenderer laserLine;
    [Header("paricle for later")]
    public GameObject startShotPT;
    public GameObject endShotPT;
    public int Ammo = 100;
    public LayerMask ufoLayer;
    CinemachineImpulseSource shake;
    [SerializeField]
    float fadeSpeed = 10;
    AudioSource sfx;


    [Header("for now not needed")]
    private float nextFire;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();

        laserLine = GetComponent<LineRenderer>();
        shake = GetComponent<CinemachineImpulseSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {         
            Shooting();
        }




    }

    public void Shooting()
    {
        if (Ammo >= 100)
        {
            sfx.Play();
            shake.GenerateImpulseAt(fpsCamera.transform.position, new Vector3(0.4f, 0.4f, 0.4f));
            StartCoroutine(ShotEffect());
            isShooting = true;
            //Start particle will be here 

            Ammo = 0;

            //   Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(.5f, .5f, 0.0f));


            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(fpsCamera.transform.position, transform.forward, out hit, Mathf.Infinity, ufoLayer))
            {
                laserLine.SetPosition(1, hit.point);
                EnemyHitBox health = hit.collider.GetComponent<EnemyHitBox>();
                if (health != null)
                {
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitforce);
                }
            }
            else
            {
                laserLine.SetPosition(1, gunEnd.position + (transform.forward * weaponRange));
            }
            //impact particle
        }
    }
    public IEnumerator ShotEffect()
    {
        //if audio needed

            laserLine.enabled = true;
            
            yield return shotDuration;
            laserLine.enabled = false;

    }
}
