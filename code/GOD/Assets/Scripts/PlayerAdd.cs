
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

    public List<Tile> GetNeighbors() {
        neighbors = new List<Tile> { };
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
        return neighbors;
    }

    private bool OnMat(Vector2 candidate) {
        if ((candidate.x < 0) || (candidate.x > 9) || (candidate.y < 0) || (candidate.y > 9)) {
            return false;
        }
        return true;
    }
}


public class PlayerAdd : MonoBehaviour {
    public GameObject player;
    private Vector2 limit;
    public int numberOfPlayers = 0;

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
        numberOfPlayers = players.Length;
        // move players if their position isn't held but a neighbor is
        // pop all player coords
        // make new
        foreach (var player in players) {
            var extras = player.GetComponent<PlayerExtras>();
            if (extras.PositionIsValid()) { continue; }
            Tile tile = extras.GetTile();
            Tile move = tile;
            foreach (var nei in tile.GetNeighbors()) {
                if (coordslist.Contains(nei.GetCoord())) {
                    move = nei;
                    break;
                }
            }
            if (move != tile)
            {
                extras.Move(move);
            }
        }
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
        foreach (var player in players) {
            if (!player.GetComponent<PlayerExtras>().PositionIsValid()) {
                Destroy(player);
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
