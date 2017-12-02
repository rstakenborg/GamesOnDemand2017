using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdd : MonoBehaviour {
    public GameObject player;
    private Vector2 limit;
    void Start()
    {
        limit = new Vector2(5, 5); // z is always -0.25 for us
        Application.runInBackground = true;
    }

    void Update()
    {
        FloorPadInput.GetEvents(gameObject);
    }

    void OnTilePressed(Vector2 coords)
    {
        //Debug.Log("Entered "+ coords);
        CreatePlayer(new Vector3(coords.x, -coords.y, 0));
    }

    void OnTileReleased(Vector2 coords)
    {
        //Debug.Log("Leaving "+ coords);
        //CreateNewBall (new Vector3 (coords.x, 10, coords.y));
    }
    void CreatePlayer(Vector3 coords) {
        Instantiate(player, coords, player.transform.rotation);
    }

}
