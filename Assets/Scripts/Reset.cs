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
        SceneManager.LoadScene("Main");

        Cell.counter = 0;
        Cell.cells = new int[9];
        Cell.lastCell = null;
    }
}
