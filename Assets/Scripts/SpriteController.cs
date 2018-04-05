using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Functionality to change the sprites (images) of the tiles.
/// </summary>
public class SpriteController : MonoBehaviour {

    /// <summary>
    /// Sprite for a default tile
    /// </summary>
    public Sprite defaultSprite;

    /// <summary>
    /// Sprite for a mine
    /// </summary>
    public Sprite mineSprite;

    /// <summary>
    /// Sprite for a secured tile
    /// </summary>
    public Sprite securedTileSprite;

    /// <summary>
    /// Sprite for a deadly-mine
    /// </summary>
    public Sprite deadlyMineSprite;

    /// <summary>
    /// Sprite for a secured mine
    /// </summary>
    public Sprite securedMineSprite;

    /// <summary>
    /// Collection of empty Tile (Number how many mines are around)
    /// </summary>
    public Sprite[] emptyTileSprites;

   
    /// <summary>
    /// Changes the tile to a sprite depending on the amount of neighboured mines
    /// </summary>
    /// <param name="amountNeighbouredMines">The amount of surrounding / Neighboured mines</param>
    public void SetEmptyTileSprite (int amountNeighbouredMines) {
        GetComponent<SpriteRenderer>().sprite = emptyTileSprites[amountNeighbouredMines];
        GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// Changes the tile-Sprite to a mine
    /// </summary>
    public void SetMineSprite () {
        GetComponent<SpriteRenderer>().sprite = mineSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    /// <summary>
    /// Changes the tile-sprite to a secured sprite
    /// </summary>
	public void SetSecuredTileSprite () {
		GetComponent<SpriteRenderer>().sprite = securedTileSprite;
	}

    /// <summary>
    /// Changes the tile-sprite to a deadly-mine
    /// </summary>
	public void SetDeadlyMineSprite () {
		GetComponent<SpriteRenderer>().sprite = deadlyMineSprite;
		GetComponent<BoxCollider2D>().enabled = false;
	}

    /// <summary>
    /// Changes the tile-sprite to a secured mine sprite
    /// </summary>
	public void SetSecuredMineSprite () {
		GetComponent<SpriteRenderer>().sprite = securedMineSprite;
		GetComponent<BoxCollider2D>().enabled = false;
	}

    /// <summary>
    /// Changes the tile-sprite to a default tile
    /// </summary>
    public void SetDefaultTileSprite () { 
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
	}
}
