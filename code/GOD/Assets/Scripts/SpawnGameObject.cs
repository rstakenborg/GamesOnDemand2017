//https://answers.unity.com/questions/17131/execute-code-every-x-seconds-with-update.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour {
    public List<string> prefabNames = new List<string> { "Bacteria" };
    //public bool enabled;
    public int cooldownSeconds;
    public int maxSeconds = 10;
    public int minSeconds = 4;
    public int minSpeed = 100;
    public int maxSpeed = 400;
    public bool rotate = true;
    public bool sin = true;
    WaitForSeconds cooldown;

    // Use this for initialization
    void Start () {
        cooldownSeconds = Random.Range(minSeconds, maxSeconds);
        enabled = enabled && (prefabNames.Count != 0);
        cooldown = new WaitForSeconds(cooldownSeconds);
        StartCoroutine("SpawnAtInterval");
    }

	// Update is called once per frame
	void Update () {
    }

    IEnumerator SpawnAtInterval()
    {
        while (true) {
            yield return cooldown;
            if (enabled)
            {
                var instance = CreateBaddie(transform.position);
            }
        }
    }

    // .. todo:: derrive another component to override this with
    GameObject CreateBaddie(Vector3 coords)
    {
        cooldownSeconds = Random.Range(minSeconds, maxSeconds);
        var name = prefabNames[Random.Range(0, prefabNames.Count)];
        var prefab = Resources.Load(name) as GameObject;
        var baddie = Instantiate(prefab, coords, prefab.transform.rotation);

        if (sin)
        {
            baddie.AddComponent<SinWaveMover>();
        }

        if (rotate)
        {
            var comp = baddie.AddComponent<Spinit>();
            comp.speedx = Random.Range(minSpeed, maxSpeed);
            // random bool
            comp.clockwise = (Random.value > 0.5f);
        }
        else {
            // .. todo:: target toward rather than "down"
            baddie.GetComponent<Rigidbody>().velocity = Vector3.down * Random.Range(minSpeed, maxSpeed);
        }

        return baddie;
    }
}
