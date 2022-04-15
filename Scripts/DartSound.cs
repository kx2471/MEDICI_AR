using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartSound : MonoBehaviour
{
    
    public GameObject sfxPosition;
    public GameObject sfxFactory;

    private void OnTriggerEnter(Collider other) {

        GameObject sfx = Instantiate(sfxFactory);
        sfx.transform.position = sfxPosition.transform.position;
        Destroy(sfx, 2);
        
    }
}
