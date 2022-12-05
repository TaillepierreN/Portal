using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    bool tp;
    GameObject portalOrange;
    GameObject portalBleu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        portalOrange = GameObject.FindWithTag("PortalOrange");
        portalBleu = GameObject.FindWithTag("PortalBleu");
        tp = GameObject.Find("GameManager").GetComponent<GameManager>().teleported;
    }
    private void OnTriggerEnter(Collider other) {
        if(gameObject.tag == "PortalOrange" && other.name == "PlayerCapsule")
        {
            other.GetComponent<CharacterController>().enabled = false;
           // other.transform.position = new Vector3(-2.070809f,0.1399998f,2.875729f);
            other.transform.position = portalBleu.transform.position + (Vector3.back*1);
            other.transform.rotation = new Quaternion(0f, 178f,0f,0f);
            tp = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().teleported = tp;
        }
        else if(other.name == "PlayerCapsule")
        {
            other.GetComponent<CharacterController>().enabled = false;
           // other.transform.position = new Vector3(2.037157f,0.1399998f,3.721665f );
            other.transform.position = portalOrange.transform.position + (Vector3.back*1);
            other.transform.rotation = new Quaternion(0f, 178f,0f,0f);
            tp = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().teleported = tp;

        }
    }
}
