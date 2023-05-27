using TMPro;
using UnityEngine;

/// <summary>
/// Component that will be added to all 9 cells
/// </summary>
public class Cell : MonoBehaviour
{
    /// <summary>
    /// Text Component that exist on this Cell. Will contain "X" or "0".
    /// </summary>
    TMP_Text textComponent;

    /// <summary>
    /// Text that is being displayed at the end of the round.
    /// </summary>
    TMP_Text winText;

    /// <summary>
    /// Number of moves in the round
    /// </summary>
    public static int counter;

    /// <summary>
    /// Array with cells. 1 - "X", 2 - "0"
    /// </summary>
    public static int[] cells = new int[9];

    /// <summary>
    /// Last cell that was clicked
    /// </summary>
    public static Cell lastCell;

    private void Start()
    {
        // Find required components
        textComponent = GetComponent<TMP_Text>();
        winText = GameObject.Find("WinText").GetComponent<TMP_Text>();
    }

    private void OnMouseDown()
    {
        // If the current cell has a value already
        // Or
        // If we have a winner
        // We don't allow clicks
        if (textComponent.text != "" || winText.text != "")
            return;

        // Remember this as being the last cell that was clicked
        lastCell = this;

        // Increase number of moves
        ++counter;

        // Was it player X, or player 0?
        if (counter % 2 == 1)
        {
            textComponent.text = "X";
            cells[name[0] - '0'] = 1;
        }
        else
        {
            textComponent.text = "0";
            cells[name[0] - '0'] = 2;
        }

        // Win conditions
        if (CheckWin())
        {
            if (counter % 2 == 1)
                winText.text = "X Wins";
            else
                winText.text = "0 Wins";
        }
        else if (counter == 9)
        {
            winText.text = "Draw";
        }
    }

    /// <summary>
    /// Returns true if a winning formation has been detected
    /// </summary>
    private bool CheckWin()
    {
        if ((cells[0] != 0 && cells[0] == cells[1] && cells[1] == cells[2])
            || (cells[3] != 0 && cells[3] == cells[4] && cells[4] == cells[5])
            || (cells[6] != 0 && cells[6] == cells[7] && cells[7] == cells[8])
            || (cells[0] != 0 && cells[0] == cells[3] && cells[3] == cells[6])
            || (cells[1] != 0 && cells[1] == cells[4] && cells[4] == cells[7])
            || (cells[2] != 0 && cells[2] == cells[5] && cells[5] == cells[8])
            || (cells[0] != 0 && cells[0] == cells[4] && cells[4] == cells[8])
            || (cells[2] != 0 && cells[2] == cells[4] && cells[4] == cells[6]))
        {
            return true;
        }

        return false;
    }
}
