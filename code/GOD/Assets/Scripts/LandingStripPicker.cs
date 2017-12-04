using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingStripPicker : MonoBehaviour {
    private Vector2 coords;
    public Sprite[] sprite;
    private void Start()
    {
        sprite = Resources.LoadAll<Sprite>("ScreenPlayIcon");
        UpdateSpriteIfNeeded();
    }

    void Update()
    {
        UpdateSpriteIfNeeded();
    }
    void UpdateSpriteIfNeeded() {
        var extras = transform.parent.GetComponent<PlayerExtras>();
        var newcoords = extras.GetPosition();
        if (coords == newcoords) { return; }
        coords = newcoords;
        int sheetNumber = Mathf.FloorToInt(coords.y);
        if (coords.x > 5)
        {
            // we're in the left columns, sheet will be 0-9
            sheetNumber += 10;
        }
        var comp = gameObject.GetComponent<SpriteRenderer>().sprite = sprite[sheetNumber];
    }
}
