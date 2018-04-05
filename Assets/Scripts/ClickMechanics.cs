using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the User-Mouse-Input: Changes the tiles-sprites and its logic behind it.
/// 
/// The Creation of the mines is in this script to make sure that the first click is no mine.
/// </summary>
public class ClickMechanics : MonoBehaviour {
    
    public Minefield minefield;     
    public SpriteController spriteController;
    public Tile tile;
        
    private void Start () {
        minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>(); // Maybe use singleton intead
        spriteController = GetComponent<SpriteController>();
        tile = GetComponent<Tile>();
    }

    private void OnMouseUpAsButton () {
        ClickTile();
    }

    public void OnMouseOver () {
        if (Input.GetMouseButtonDown(1)) {
            if (tile.isSecured) {
                spriteController.SetDefaultTileSprite();
                tile.isSecured = false;
                minefield.minesLeft++;
            } else {
                spriteController.SetSecuredTileSprite();
                tile.isSecured = true;
                minefield.minesLeft--;
            }
        }
    }

    /// <summary>
    /// Mechanic for Clicking on a tile
    /// </summary>
    public void ClickTile () {
        
        //  If game has not been started yet
        if (!minefield.hasGameStarted) {
            minefield.hasGameStarted = true;

            CreateMines();
            minefield.timer.StartTimer();
        }

        //  If the tile is a mine --> end of the game
        if (tile.isMine) {
            minefield.LoseGame();
            return;
        } 

        //  Reveal all nearby tiles
        RevealTile();

        //  Check if game is won
        if (minefield.IsGameWon()) {
            minefield.WinGame();
        }
    }

    /// <summary>
    /// Creates mines randomly about the field.
    /// </summary>
    private void CreateMines () {
        Debug.Log("Create Mines");
                
        int minesLeft = minefield.amountMines;
        int tilesLeft = minefield.amountTilesUnrevealed;

        //  go through the whole minefield
        for (int x = 0; x < minefield.xTotal; x++) {
            for (int y = 0; y < minefield.yTotal; y++) {

                if (!(x== tile.x && y == tile.y)) {
                    Tile aTile = minefield.tiles[x, y];

                    //  Create a chance depending on how many mines are left, to create mine
                    float chanceForMine = (float) minesLeft / (float) tilesLeft;

                    if (Random.value <= chanceForMine) {
                        aTile.isMine = true;
                        minesLeft--;
                    }

                }
                tilesLeft--;
            }
        }
    }
    
    /// <summary>
    /// Reveals a tile
    /// </summary>
    private void RevealTile () {

        //  If tile is not revealed yet and its not a mine
        if (!tile.isReveald && !tile.isMine) {
            tile.isReveald = true;
            minefield.amountTilesUnrevealed--;

            int amountNeighbourMines = GetAmountNeighbourMines();

            spriteController.SetEmptyTileSprite(amountNeighbourMines);

            //  If there is no Nightbour Mine
            if (amountNeighbourMines == 0) {

                //  Check all tiles  on the left
                RevealIfValid(tile.x - 1, tile.y - 1);
                RevealIfValid(tile.x - 1, tile.y);
                RevealIfValid(tile.x - 1, tile.y + 1);

                //  Check the tile on the bottom
                RevealIfValid(tile.x, tile.y - 1);

                //  Check the tile on the top
                RevealIfValid(tile.x, tile.y + 1);

                //  Check all tiles on the right
                RevealIfValid(tile.x + 1, tile.y - 1);
                RevealIfValid(tile.x + 1, tile.y);
                RevealIfValid(tile.x + 1, tile.y + 1);
            }
        }
    }

    /// <summary>
    /// Reveals a given Tile and triggers its mechanic.
    /// </summary>
    /// <param name="x">The X-Position to reveal</param>
    /// <param name="y">The Y-Position to reveal</param>
    private void RevealIfValid (int x, int y) {
        if (x >= 0 && x < minefield.xTotal 
            && y >= 0 && y < minefield.yTotal) {
            minefield.tiles[x, y].clickMechanics.RevealTile();
        }
    }

    /// <summary>
    /// Calculates the Amount of nearby mines.
    /// Nerby/Neightbour means surrounding tiles by 1 tile
    /// </summary>
    /// <returns>The Amount of neightbour mines</returns>
    private int GetAmountNeighbourMines () {
        int mineCounter = 0;

        //  Check all tiles on the left
        if (HasMine(tile.x - 1, tile.y - 1)) mineCounter++;
        if (HasMine(tile.x - 1, tile.y )) mineCounter++;
        if (HasMine(tile.x - 1, tile.y + 1)) mineCounter++;

        //  Check the tile on the bottom
        if (HasMine(tile.x, tile.y - 1)) mineCounter++;

        //  Check the tile on the top
        if (HasMine(tile.x, tile.y + 1)) mineCounter++;

        //  Check all tiles on the right
        if (HasMine(tile.x + 1, tile.y - 1)) mineCounter++;
        if (HasMine(tile.x + 1, tile.y)) mineCounter++;
        if (HasMine(tile.x + 1, tile.y + 1)) mineCounter++;

        return mineCounter;
    }

    /// <summary>
    /// Checks if a specific tile is a mine
    /// </summary>
    /// <param name="x">The X-Position to check</param>
    /// <param name="y">The Y-Position to check</param>
    /// <returns>Returns TRUE if the given Position is a mine. Returns FALSE otherwise</returns>
    private bool HasMine (int x, int y) {
        bool hasMine = false;

        if (x >= 0 && x < minefield.xTotal && y >= 0 && y < minefield.yTotal) {
            hasMine = minefield.tiles[x, y].isMine;
        }

        return hasMine;
    }
}
