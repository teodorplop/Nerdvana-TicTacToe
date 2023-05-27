using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Component responsible for resetting the game
/// </summary>
public class Reset : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PerformReset();
        }
    }

    /// <summary>
    /// Resets the game
    /// </summary>
    private void PerformReset()
    {
        // Reload the scene
        // This will reset all changed GameObjects
        SceneManager.LoadScene("Main");

        // Reset the number of moves
        Cell.counter = 0;
        // Reset cells array
        Cell.cells = new int[9];
        // Reset the last cell that was clicked
        Cell.lastCell = null;
    }
}
