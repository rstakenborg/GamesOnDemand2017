using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {
    public List<Tile> neighbors;
    Vector2 coord;
    static private Vector2 matminmax = new Vector2(0, 9);

    public Tile(Vector2 incoord) {
        coord = incoord;
    }

    public Vector2 GetCoord() {
        return coord;
    }
    private void SetNeighbors() {
        foreach (var candidate in new List<Vector2> {
                new Vector2(coord.x + 1, coord.y),
                new Vector2(coord.x - 1, coord.y),
                new Vector2(coord.x, coord.y + 1),
                new Vector2(coord.x, coord.y - 1)
            }) {
            // .. note:: we do not check the diagonal neighbors for this, but maybe we'll have to?
            if (OnMat(candidate)){
                neighbors.Add(new Tile(candidate));
            }
        }

    }

    private bool OnMat(Vector2 candidate) {
        if ((candidate.x < coord.x) || (candidate.x > coord.y) || (candidate.y < coord.x) || (candidate.y > coord.y)) { return false; }
        return true;
    }
}


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
        var coordslist = FloorPadInput.GetPressedCoordinates();
        var players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var coord in coordslist) {
            bool make = true;
            foreach (var player in players) {
                if (player.GetComponent<PlayerExtras>().GetPosition() == coord) {
                    make = false;
                    break;
                }
            }
            if (make) {
                CreatePlayer(coord);
            }
        }
    }

    void GetPressedCoordinates(Vector2[] coordslist) {
        // todo:: for each player, move if a neighbor is lit and their coord isn't
        //Debug.Log(coordslist);
    }

    void OnTilePressed(Vector2 coords)
    {
        //Debug.Log("Entered "+ coords);
        //var New = CreatePlayer(new Vector3(coords.x, -coords.y, 0));
    }

    void OnTileReleased(Vector2 coords)
    {
        //Debug.Log("Leaving "+ coords);
        //CreateNewBall (new Vector3 (coords.x, 10, coords.y));
    }
    GameObject CreatePlayer(Vector3 coords) {
        return Instantiate(player, coords, player.transform.rotation);
    }

}
