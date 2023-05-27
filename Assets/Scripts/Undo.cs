using TMPro;
using UnityEngine;

/// <summary>
/// Component responsible for undoing the last move
/// </summary>
public class Undo : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && Cell.lastCell != null)
        {
            PerformUndo();
        }
    }

    /// <summary>
    /// Undo
    /// </summary>
    private void PerformUndo()
    {
        // Nothing to undo
        if (Cell.lastCell == null)
            return;

        // Get cell position
        int pos = Cell.lastCell.name[0] - '0';

        // Reset value from array
        Cell.cells[pos] = 0;
        
        // Decrease number of moves
        Cell.counter--;

        // Reset the text
        Cell.lastCell.GetComponent<TMP_Text>().text = "";

        // Undo is done, we reset the last cell
        Cell.lastCell = null;
    }
}
