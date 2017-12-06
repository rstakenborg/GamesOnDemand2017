using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAndDestroy : MonoBehaviour {

    public float cooldownSeconds = 0.01f;
    public bool alive = true;
    private List<GameObject> antibodies;
    public int health = 2;
    WaitForSeconds cooldown;
	// Use this for initialization
	void Start () {
        antibodies = new List<GameObject> { };
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DelayDestroy(GameObject other) {
        var comp = GetComponent<Spinit>();
        if (comp) {
            comp.Reverse();
        }
        if (!alive) { return;  }
        antibodies.Add(other);
        cooldown = new WaitForSeconds(cooldownSeconds);
        if (antibodies.Count >= health) {
            StartCoroutine("ShrinkToKill");
        }
        
    }

    IEnumerator ShrinkToKill()
    {
        alive = false;
        while (true) {
            // grow so the effect is bigger
            yield return cooldown;
            if (transform.localScale.x >= 0.2f)
            {
                break;
            }
            var scale = transform.localScale;
            scale.x += 0.1f;
            scale.y += 0.1f;
            scale.z += 0.1f;
            transform.localScale = scale;
        } 
        while (true)
        {
            yield return cooldown;
            if (transform.localScale.x <= 0.0f)
            {
                foreach (var go in antibodies) {
                    Destroy(go);
                }
                Destroy(gameObject);
            }
            var scale = transform.localScale;
            scale.x -= 0.1f;
            scale.y -= 0.1f;
            scale.z -= 0.1f;
            transform.localScale = scale;
        }
    }
}
