using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunAim : MonoBehaviour
{

    public Transform aimPoint;
    public Transform gunPos;
    public Transform armBase;
    public Transform aimPivot;
    public float step;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aimPoint && gunPos)
        {
            //Vector3 dir = (aimPivot.position - aimPoint.position).normalized;
            //Debug.Log(dir);
            //Debug.DrawRay(aimPivot.position, -dir, Color.red, 1f);

           // float angl = Vector2.Angle(new Vector2(armBase.position.x, armBase.position.z), new Vector2(aimPoint.position.x, aimPoint.position.z));
            //Debug.Log(angl);
            //armBase.localEulerAngles = new Vector3(armBase.eulerAngles.x, angl, armBase.eulerAngles.z);

            //armBase.rotation = Quaternion.LookRotation(Vector3.RotateTowards(armBase.forward, dir, step, 0.0f));
            gunPos.LookAt(aimPoint,Vector3.left);
        }
    }
}
