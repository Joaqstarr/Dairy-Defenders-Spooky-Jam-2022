using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class podInputScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI uiNotif;
    bool interactable = true;
    public GameObject explodeParticle;

    private void Start()
    {
        uiNotif = GameObject.Find("Activate Pod").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetAxis("Interact") > 0)
        {
            uiNotif.enabled = false;
            //GetComponent<SphereCollider>().enabled = false;
            GetComponent<PodAttackScript>().Attack();
            bool interactable = false;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && interactable == true)
        {
            uiNotif.enabled = true;
        }
        if(other.tag == "mothership")
        {
            explodeParticle = (GameObject)(Instantiate(explodeParticle, transform.position, Quaternion.identity));
            Destroy(explodeParticle, 4f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && interactable == true)
        {
            uiNotif.enabled = false;
        }
    }
}
