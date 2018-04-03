using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMechanics : MonoBehaviour {

    public Minefield minefield;
    public SpriteController spriteController;
    public Tile tile;
        
    void Start () {
        this.minefield = GameObject.FindGameObjectWithTag("Minefield").GetComponent<Minefield>();
        this.spriteController = this.GetComponent<SpriteController>();
        this.tile = this.GetComponent<Tile>();
    }

    private void OnMouseUpAsButton () {
        this.ClickTile();
    }

    public void OnMouseOver () {
        if(Input.GetMouseButtonDown(1)){
            if(this.tile.isSecured){
                this.spriteController.SetDefaultTileSprite();
                this.tile.isSecured = false;
                this.minefield.minesLeft++;
            }else{
                this.spriteController.SetSecuredTileSprite();
                this.tile.isSecured = true;
                this.minefield.minesLeft--;
            }
        }
    }

    /// <summary>
    /// Mechanic for Clicking on a tile
    /// </summary>
    public void ClickTile () {
        
        //  If game has not been started yet
        if (!this.minefield.hasGameStarted) {
            this.minefield.hasGameStarted = true;

            this.CreateMines();
            this.minefield.timer.StartTimer();
        }

        //  If the tile is a mine --> end of the game
        if (this.tile.isMine) {
            this.minefield.LoseGame();
            return;
        } 


        this.RevealTile();

        if (this.minefield.IsGameWon()) {
            this.minefield.WinGame();
        }
        

    }

    /// <summary>
    /// Creates mines randomly about the field
    /// </summary>
    private  void CreateMines () {
        Debug.Log("Create Mines");

        int minesLeft = this.minefield.amountMines;
        int tilesLeft = this.minefield.amountTilesUnrevealed;

        for (int x = 0; x < this.minefield.xTotal; x++) {
            for (int y = 0; y < this.minefield.yTotal; y++) {

                if (!(x== this.tile.x && y == this.tile.y)) {
                    Tile aTile = this.minefield.tiles[x, y];

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
        if (!this.tile.isReveald && !this.tile.isMine) {
            this.tile.isReveald = true;
            this.minefield.amountTilesUnrevealed--;

            int amountNeighbourMines = this.GetAmountNeighbourMines();

            this.spriteController.SetEmptyTileSprite(amountNeighbourMines);

            //  If there is no Nightbour Mine
            if (amountNeighbourMines == 0) {
                this.RevealIfValid(this.tile.x - 1, this.tile.y - 1);
                this.RevealIfValid(this.tile.x - 1, this.tile.y);
                this.RevealIfValid(this.tile.x - 1, this.tile.y + 1);

                this.RevealIfValid(this.tile.x, this.tile.y - 1);

                this.RevealIfValid(this.tile.x, this.tile.y + 1);

                this.RevealIfValid(this.tile.x + 1, this.tile.y - 1);
                this.RevealIfValid(this.tile.x + 1, this.tile.y);
                this.RevealIfValid(this.tile.x + 1, this.tile.y + 1);
            }
        }
    }

    /// <summary>
    /// Reveals a given Tile and triggers its mechanic.
    /// </summary>
    /// <param name="x">The X-Position to reveal</param>
    /// <param name="y">The Y-Position to reveal</param>
    private void RevealIfValid (int x, int y) {
        if( x >= 0 && x < this.minefield.xTotal 
            && y >= 0 && y < this.minefield.yTotal){
            this.minefield.tiles[x, y].clickMechanics.RevealTile();
        }
    }

    /// <summary>
    /// Calculates the Amount of nearby mines.
    /// Nerby/Neightbour means surrounding tiles by 1 tile
    /// </summary>
    /// <returns>The Amount of neightbour mines</returns>
    private int GetAmountNeighbourMines () {
        int mineCounter = 0;

        if (this.HasMine(this.tile.x - 1, this.tile.y - 1)) mineCounter++;
        if (this.HasMine(this.tile.x - 1, this.tile.y )) mineCounter++;
        if (this.HasMine(this.tile.x - 1, this.tile.y + 1)) mineCounter++;

        if (this.HasMine(this.tile.x, this.tile.y - 1)) mineCounter++;

        if (this.HasMine(this.tile.x, this.tile.y + 1)) mineCounter++;

        if (this.HasMine(this.tile.x + 1, this.tile.y - 1)) mineCounter++;
        if (this.HasMine(this.tile.x + 1, this.tile.y)) mineCounter++;
        if (this.HasMine(this.tile.x + 1, this.tile.y + 1)) mineCounter++;

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

        if (x >= 0 && x < this.minefield.xTotal && y >= 0 && y < this.minefield.yTotal) {
                hasMine = this.minefield.tiles[x, y].isMine;
        }

        return hasMine;
    }
}
