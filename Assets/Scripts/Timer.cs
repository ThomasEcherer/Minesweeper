using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A timer to count the passed time from the gamestart to the end.
/// </summary>
public class Timer : MonoBehaviour {

    public Text timerText;
    System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

    private void FixedUpdate () {
        int currentTime = this.GetCurrentTime();
        this.timerText.text = currentTime.ToString();
    }

    /// <summary>
    /// Resets the timer
    /// </summary>
    public void ResetTimer () {
        stopwatch.Reset();
    }

    /// <summary>
    /// Starts the timer
    /// </summary>
    public void StartTimer () {
        this.ResetTimer();
        stopwatch.Start();
    }

    /// <summary>
    /// Stops the timer
    /// </summary>
    public void StopTimer () {
        stopwatch.Stop();
    }

    /// <summary>
    /// Read the current time of the stopwatch
    /// </summary>
    /// <returns>The current Time in Milliseconds</returns>
    public int GetCurrentTime () {
        return (int) (this.stopwatch.ElapsedMilliseconds / 1000f);
    }


}
