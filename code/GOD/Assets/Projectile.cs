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
            //transform.SetParent(col.gameObject.transform);
            var comp = col.gameObject.GetComponent<FadeAndDestroy>();
            if (comp)
            {
                // todo:: should we skip this if there's alot of players?
                transform.parent = col.gameObject.transform;
                Destroy(gameObject.GetComponent<Spinit>());
                var joint = col.gameObject.AddComponent<FixedJoint>();
                var rigidbody = gameObject.GetComponent<Rigidbody>();
                joint.connectedBody = rigidbody;
                rigidbody.isKinematic = true;
                comp.DelayDestroy(gameObject);
                //Destroy(this);
                transform.localRotation = new Quaternion(transform.rotation.w, 0.0f, 0.0f, -90.0f);
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                transform.localPosition = new Vector3(0.0f, -2.25f, -0.5f);
                Destroy(gameObject.GetComponent<MeshCollider>());
            }
            else {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
            
        }
    }
}
