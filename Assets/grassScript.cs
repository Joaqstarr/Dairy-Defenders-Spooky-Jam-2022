using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class grassScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI uiNotif;
    BoxCollider col;
    GameObject player;
    BoxCollider playerCol;
    [SerializeField]
    int ammo = 5;
    bool sneak = false;
    RectTransform canv;
    Transform cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        canv = transform.GetChild(1).gameObject.GetComponent<RectTransform>();
        player = GameObject.Find("PlayerCow");
        playerCol = player.GetComponent<BoxCollider>();
        col = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (col.bounds.Intersects(playerCol.bounds))
        {

            if(sneak == false)
            {
                Sneak(true);
            }


            //Debug.Log("hiding");
            uiNotif.enabled = true;

            canv.LookAt(cam);

            if(Input.GetAxis("Interact") > 0)
            {
                Eat();
            }
            sneak = true;
        }
        else
        {
            if(sneak == true)
            {
                Sneak(false);
            }


            uiNotif.enabled = false;
            sneak = false;
        }
    }

    void Sneak(bool val)
    {
        if (val)
        {
            player.GetComponent<player_Movement>().Sneaking += 1;
        }
        else
        {
            player.GetComponent<player_Movement>().Sneaking -= 1;

        }
    }

    void Eat()
    {
        player.GetComponent<Aim2>().barrels.GetComponent<rayCastShoot>().Ammo += ammo;
        Destroy(gameObject);
    }

}
