using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    GameObject portalOrange,portalBleu, instanciatedOrange, insatnciatedBleu;
    [SerializeField] GameObject prefabOrange, prefabBleu;
    public bool teleported;
    Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(teleported)
         {
         GameObject.Find("PlayerCapsule").GetComponent<CharacterController>().enabled = true;
         teleported = false;
         }
        portalOrange = GameObject.Find("PortalOrange");
        portalBleu = GameObject.Find("PortalBleu");
        if( Input.GetButtonDown("Fire1") )
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit))
            {
                destination = hit.point;
            }
            if( portalOrange!=null )
            {
                Destroy(portalOrange);
            }
            if( instanciatedOrange !=null )
            {
                Destroy(instanciatedOrange);
            }
            instanciatedOrange = Instantiate(prefabOrange,destination, Quaternion.identity);
            //instanciatedOrange.transform.SetParent(hit.transform);
            instanciatedOrange.transform.up = hit.normal;
            Debug.Log(hit.normal);
           /* if(hit.normal == new Vector3(-1f,0f,0f))
            {

            }*/
            instanciatedOrange.transform.rotation = instanciatedOrange.transform.rotation  /* * new Quaternion(0f,10f,0f,0f)*/;

        }
        if(Input.GetButtonDown("Fire2"))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            if(Physics.Raycast(ray , out hit))
            {
                destination = hit.point;
            }
            if(portalBleu!=null)
            {
                Destroy(portalBleu);
            }
            if(insatnciatedBleu !=null)
            {
                Debug.Log("boumbleu");
                Destroy(insatnciatedBleu);
            }
            insatnciatedBleu = Instantiate(prefabBleu, destination, Quaternion.identity);
            insatnciatedBleu.transform.up = hit.normal;
        }
    }
}
