using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour
{
    [SerializeField]
    ufoHover tutUFO;
    bool first = false;
    // Start is called before the first frame update
    void Start()
    {
        tutUFO = GameObject.Find("TutorialUFO").GetComponent<ufoHover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(first == false)
            {
                tutUFO.patrolPoints[0] = transform.GetChild(0);
            }

            first = true;
        }
    }
}
