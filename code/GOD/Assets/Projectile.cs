using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        // on collision we should 
        if (col.gameObject.tag == "Baddie") {
            var comp = col.gameObject.GetComponent<FadeAndDestroy>();
            if (comp)
            {
                comp.DelayDestroy();
            }
            else {
                Destroy(col.gameObject);
            }
            
        }
        Destroy(gameObject);
    }
}
