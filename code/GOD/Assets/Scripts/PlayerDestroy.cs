using UnityEngine;

public class PlayerDestroy : MonoBehaviour {

    void Start()
    {
        Application.runInBackground = true;
    }

    void Update()
    {
        FloorPadInput.GetEvents(gameObject);
    }

    void OnTilePressed(Vector2 coords)
    {
        //Debug.Log("Entered " + coords);
        //CreateNewBall(new Vector3(coords.x, 10, -coords.y));
    }

    void OnTileReleased(Vector2 coords)
    {   
        //Debug.Log("Leaving " + coords);
        //CreateNewBall (new Vector3 (coords.x, 10, coords.y));
    }

}
