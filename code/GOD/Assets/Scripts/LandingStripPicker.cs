﻿using System.Collections;
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
        var cell = transform.parent.GetChild(1);
        var pos = new Vector3(coords.x -2, 0, 0);
        coords = newcoords;
        int sheetNumber = Mathf.FloorToInt(coords.y);
        if (coords.x > 4)
        {
            // we're in the left columns, sheet will be 0-9
            sheetNumber += 10;
            pos.x -= 5;
        }
        // spritesheet middle is 0
        pos.x += coords.x;
        cell.transform.localPosition = pos;
        var comp = gameObject.GetComponent<SpriteRenderer>().sprite = sprite[sheetNumber];
    }
}
