using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Minefield to solve.
/// Contents the Amount of Columns and Rows. 
/// </summary>
public class Minefield : MonoBehaviour {

    /// <summary>
    /// The Amount of mines inside the minefield
    /// </summary>
    public int amountMines;

    /// <summary>
    /// The Amount of unrevealed tiles.
    /// </summary>
    public int amountTilesUnrevealed;

    /// <summary>
    /// Flag if the game has already started
    /// </summary>
    public bool hasGameStarted = false;

    /// <summary>
    /// The total amount of columns of the minefield
    /// </summary>
    public int xTotal;

    /// <summary>
    /// The total amount of rows of the minefield
    /// </summary>
    public int yTotal;

    /// <summary>
    /// A 2D-Array of the tiles of the minefield
    /// </summary>
    public Tile[,] tiles;

    /// <summary>
    /// Timer to record the time the game is running
    /// </summary>
    public Timer timer;


    public ResetGameButton resetGameButton;
    public HighScore highscore;
    public int minesLeft = 0;

    /// <summary>
    /// Creates the Minefield
    /// </summary>
    /// <param name="xTotal">Amount of Columny to create</param>
    /// <param name="yTotal">Amount of Rows to create</param>
    /// <param name="amountMines">Amount of mines to create</param>
    public void CreateMineField (int xTotal, int yTotal, int amountMines) {

        //  save Starting parameters
        this.xTotal = xTotal;
        this.yTotal = yTotal;
        this.amountMines = amountMines;

        //  Init Game
        amountTilesUnrevealed = xTotal * yTotal;
        hasGameStarted = false;
        minesLeft = amountMines;
        timer.ResetTimer();
        resetGameButton.SetNeutral();

        //  Delete Tiles if there are tiles already
        if (tiles != null) {
            foreach (Tile tile in tiles) {
                Destroy(tile.gameObject);
            }
        }

        //  Initalize tiles
        tiles = new Tile[xTotal, yTotal];

        //  Create the tiles for the minefield
        for (int x = 0; x < xTotal; x++) {
            for (int y = 0; y < yTotal; y++) {
                tiles[x, y] = Tile.CreateNewTile(x, y);
            }
        }

        //  Move UI-Bars to correct positions
        GameObject.FindGameObjectWithTag("TopBar").GetComponent<Bar>().SetPosition(this);
        GameObject.FindGameObjectWithTag("BottomBar").GetComponent<Bar>().SetPosition(this);
    }

    /// <summary>
    /// Determines if the Game is won
    /// </summary>
    /// <returns>Returns TRUE if the game is won. Returns FALSE otherwise</returns>
    public bool IsGameWon() {
        if (amountTilesUnrevealed == amountMines) {
            return true;
        } else {
            return false;
        }
    }
	
    /// <summary>
    /// Mechanic for loosing the game
    /// </summary>
    public void LoseGame() {
        Debug.Log("Game Lost");
        timer.StopTimer();
        resetGameButton.SetSad();

        foreach (Tile tile in tiles) {
            if (!tile.isMine) {
                tile.GetComponent<BoxCollider2D>().enabled = false;
            } else {
                tile.spriteController.SetMineSprite();
            }
        }
    }

    /// <summary>
    /// Mechanic for winning the game
    /// </summary>
    public void WinGame() {
        Debug.Log("Win Game");

        timer.StopTimer();
        resetGameButton.SetHappy();

        foreach (Tile tile in tiles) {
            if (tile.isMine) {
                tile.spriteController.SetSecuredMineSprite();
            }
        }

        highscore.UpdateHighscore(timer.GetCurrentTime());
    }

}
