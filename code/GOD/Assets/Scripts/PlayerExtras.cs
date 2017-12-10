using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtras : MonoBehaviour {

    public List<Tile> tiles;
    void Start() {
        tiles = new List<Tile> { };
        var coord = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        var tile = new Tile(coord);
        AddTile(tile);
    }

    public Tile GetTile()
    {
        return tiles[0];
    }

    public Vector2 GetPosition() {
        // .. todo:: return lowest Vector2 by x first, y second
        return tiles[0].GetCoord();
    }

    public bool PositionIsValid() {
        var pos = GetPosition();
        return (FloorPadInput.GetPressedCoordinates().Contains(pos));
    }
    public void Move(Tile moveto) {
        // .. todo:: if moveto is empty and in neighbors
        var tile = GetTile();
        var mtcoord = moveto.GetCoord();
        transform.position = new Vector3(mtcoord.x, mtcoord.y, gameObject.transform.position.z);
        tiles.Add(moveto);
        if (tile != null) {
            tiles.Remove(tile);
        }
        
    }

    void AddTile(Tile addme) {
        tiles.Add(addme);
    }

    void RemoveTile(Tile remove) {
        tiles.Remove(remove);
    }

    int GetSize() {
        return tiles.Count;
    }

    void Resize() {
        // .. todo:: if the list of "indexes" is 4, scale x2
    }

	// Update is called once per frame
	void Update () {
        FloorPadInput.GetEvents(gameObject);
    }
}
