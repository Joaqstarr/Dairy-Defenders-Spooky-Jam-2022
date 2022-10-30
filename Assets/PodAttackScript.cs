using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PodAttackScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    GameObject mothership;
    bool attacking = false;
    [SerializeField]
    float speed;
    float flyingspeed = 0;
    [SerializeField]
    float flyingAccel = 1;
    private void Start()
    {
        mothership = GameObject.Find("MOTHERSHIP");

        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 2, Color.yellow, 1f);
        Debug.DrawRay(transform.position, transform.right * 2, Color.blue, 1f);
        Debug.DrawRay(transform.position, transform.up * 2, Color.green, 1f);

        if (attacking == false)
        {
            return;
        }
        flyingspeed += Time.deltaTime * flyingAccel;
       rb.velocity = transform.forward * flyingspeed;

        //Now Turn the Rocket towards the Target
        var rocketTargetRot = Quaternion.LookRotation(mothership.transform.position - transform.position,transform.up);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRot, speed));
    }
    public void Attack()
    {
        //Attack
        rb.isKinematic = false;
        //rb.velocity = new Vector3(0, 15, 0);
        attacking = true;
        mothership.GetComponent<winScript>().hit();


    }
}
