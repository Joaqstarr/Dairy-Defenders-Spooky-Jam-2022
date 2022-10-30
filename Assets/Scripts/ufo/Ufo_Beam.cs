using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ufo_Beam : MonoBehaviour
{
    ufoHover hoverScript;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        hoverScript = transform.parent.gameObject.GetComponent<ufoHover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            aud.Play();
            Debug.Log("lose");
            hoverScript.BeamPlayer(other.gameObject);
        }
    }
}
