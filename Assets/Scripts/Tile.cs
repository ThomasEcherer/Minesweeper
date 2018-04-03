using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Tile of the minefield.
/// A Tile can either be revealed or not or if it is a mine or not. as well as secured or not.
/// </summary>
public class Tile : MonoBehaviour {

    /// <summary>
    /// X-Position of the tile
    /// </summary>
    public int x;

    /// <summary>
    /// Y-Position of the tile
    /// </summary>
    public int y;

    /// <summary>
    /// Flag if the tile is a mine
    /// </summary>
    public bool isMine = false;

    /// <summary>
    /// Flag if the tile is revlead
    /// </summary>
    public bool isReveald = false;

    /// <summary>
    /// Flag if the mine is secured
    /// </summary>
    public bool isSecured = false;

    /// <summary>
    /// The Click-Mechanic-Script
    /// </summary>
    public ClickMechanics clickMechanics;

    /// <summary>
    /// The Sprite-Controller-Script
    /// </summary>
    public SpriteController spriteController;

    private void Start () {
        this.clickMechanics = this.GetComponent<ClickMechanics>();
        this.spriteController = this.GetComponent<SpriteController>();
    }

    /// <summary>
    /// Creates a new Tile
    /// </summary>
    /// <param name="x">The X-Position to create the new Tile</param>
    /// <param name="y">The y-Position to create the new Tile</param>
    /// <returns>The created tile</returns>
    public static Tile CreateNewTile (int x, int y) {
        
        //  Instantiate the new Tile
        GameObject tile = (GameObject) Instantiate(Resources.Load("Prefabs/Tile"));

        //  Find the parent (for hirachy)
        GameObject tiles = GameObject.FindGameObjectWithTag("Tiles");

        //  Find the minefield
        Minefield mineField = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();

        //  Inherit the Positions to the Tile-Script-Child
        tile.GetComponent<Tile>().x = x;
        tile.GetComponent<Tile>().y = y;

        //  Move it into the parent (hirachy)
        tile.transform.parent = tiles.transform;

        //  Set Position within the minefield
        tile.transform.position = new Vector2(
            (float) x - ((float) mineField.xTotal - 1f) / 2f, 
            (float) y - ((float) mineField.yTotal - 1f) / 2f
        );

        //  Return the created tile
        return tile.GetComponent<Tile>();
    }
}
