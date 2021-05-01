using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerHit : MonoBehaviour
{
    
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Obstacle>() != null) {
            Debug.Log(col.gameObject.name);
        }
        else if (col.gameObject.GetComponent<Collectible>() != null) {
            Debug.Log(col.gameObject.name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
