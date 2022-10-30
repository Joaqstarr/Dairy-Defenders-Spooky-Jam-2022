using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankScript : MonoBehaviour
{
    public rayCastShoot ammo;
    [SerializeField]
    GameObject part;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo.Ammo >= 100)
        {
            part.SetActive(true);
        }
        else
        {
            part.SetActive(false);

        }
        transform.localScale = new Vector3(1,Mathf.Clamp01( ammo.Ammo/100f),1);
    }
}
