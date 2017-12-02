using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingStripPicker : MonoBehaviour {

    void Update()
    {
        FloorPadInput.GetEvents(gameObject);
    }

    void OnTilePressed(Vector2 coords)
    {
        Debug.Log("Entered " + coords);
        float sheetNumber = coords.y;
        if (coords.x > 5.0) {
            // we're in the left columns, sheet will be 0-9
            sheetNumber += 10.0f;
        }
        Debug.Log("Spritesheet " + sheetNumber);
    }

    void OnTileReleased(Vector2 coords)
    {
        //Debug.Log("Leaving " + coords);
        //CreateNewBall (new Vector3 (coords.x, 10, coords.y));
    }

}
