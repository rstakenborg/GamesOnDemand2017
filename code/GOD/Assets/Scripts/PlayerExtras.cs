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
    public Vector2 GetPosition() {
        // .. todo:: return lowest Vector2 by x first, y second
        return tiles[0].GetCoord();
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
	}
}
