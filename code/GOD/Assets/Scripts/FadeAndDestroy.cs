using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAndDestroy : MonoBehaviour {

    public float cooldownSeconds = 0.01f;
    public bool alive = true;
    WaitForSeconds cooldown;
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DelayDestroy() {
        var comp = GetComponent<Spinit>();
        if (comp) {
            comp.Reverse();
        }
        if (!alive) { return;  }
        cooldown = new WaitForSeconds(cooldownSeconds);
        StartCoroutine("ShrinkToKill");
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
