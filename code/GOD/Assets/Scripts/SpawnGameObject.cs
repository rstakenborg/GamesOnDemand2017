//https://answers.unity.com/questions/17131/execute-code-every-x-seconds-with-update.html
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnGameObject : MonoBehaviour {
    private List<string> prefabNames = new List<string> { "Bacteria" };
    public bool enabled;
    private int cooldownSeconds;
    WaitForSeconds cooldown;

    // Use this for initialization
    void Start () {
        cooldownSeconds = Random.Range(4, 10);
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

    GameObject CreateBaddie(Vector3 coords)
    {
        cooldownSeconds = Random.Range(4, 10);
        var name = prefabNames[Random.Range(0, prefabNames.Count)];
        var prefab = Resources.Load(name) as GameObject;
        var baddie = Instantiate(prefab, coords, prefab.transform.rotation);
        // .. todo:: pick a mover
        baddie.AddComponent<SinWaveMover>();
        var comp = baddie.AddComponent<Spinit>();
        comp.speedx = Random.Range(100, 500);
        // random bool
        comp.clockwise = (Random.value > 0.5f);
        return baddie;
    }
}
