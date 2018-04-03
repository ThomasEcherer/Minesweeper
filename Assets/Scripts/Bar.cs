using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Repositoning the Bar-Y-Location.
/// </summary>
public class Bar : MonoBehaviour {
	
    /// <summary>
    /// Flag if it this bar is Top or Bottom Bar
    /// </summary>
    public bool topBar = true;

    private float height;
        
    private void Start () { 		
        RectTransform rt = GetComponent<RectTransform>();
        height = rt.rect.height;
	}

    /// <summary>
    /// Sets the position of this Bar regarding to the size of the minefield
    /// </summary>
    /// <param name="minefield">The Minefield that calls this position. And has the information about the size of the minefield</param>
    public void SetPosition (Minefield minefield) {
        transform.position = topBar ? new Vector2(0, +((minefield.yTotal - 1f) / 2f + 2f)) : new Vector2(0, -((minefield.yTotal - 1f) / 2f + 2f));
        RectTransform rectTrans = (RectTransform) transform;
        rectTrans.sizeDelta = new Vector2(minefield.xTotal + height, height);
    }
}
