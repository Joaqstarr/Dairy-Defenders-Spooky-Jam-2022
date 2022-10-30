using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Ufo_Beam : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    ufoHover hoverScript;
    AudioSource aud;
    [SerializeField]
    GameObject lose;
    bool changed = false;
    // Start is called before the first frame update
    void Start()
    {
        lose = GameObject.Find("lose");
        Debug.Log(lose);

        
        cam = GameObject.Find("ufoSuckCam").GetComponent<CinemachineVirtualCamera>();
        aud = GetComponent<AudioSource>();
        hoverScript = transform.parent.gameObject.GetComponent<ufoHover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.gameObject.name == "TutorialUFO" && changed == false)
        {
            lose.SetActive(false);
            changed = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            lose.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            aud.Play();
            Debug.Log("lose");
            hoverScript.BeamPlayer(other.gameObject);
            cam.Follow = transform.parent;
        }
    }
}
