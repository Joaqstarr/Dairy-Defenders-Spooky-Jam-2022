using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour
{
    [SerializeField]
    GameObject podHolder;
    public int health = 1;
    bool won = false;
    // Start is called before the first frame update
    void Start()
    {
        health = podHolder.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0 && won == false)
        {
            Win();
            won = true;
        }
    }
    void Win()
    {
        //win stuff
        Debug.Log("win!!");
    }
    public void hit()
    {

        health = health - 1;
    }
}
