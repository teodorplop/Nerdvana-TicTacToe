using TMPro;
using UnityEngine;

public class Cell : MonoBehaviour
{
    TMP_Text textComponent;
    TMP_Text winText;

    static int counter;
    static int winner;
    static int[] cells = new int[9];

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        winText = GameObject.Find("WinText").GetComponent<TMP_Text>();
    }

    private void OnMouseDown()
    {
        if (textComponent.text != "" || winText.text != "")
            return;

        ++counter;
        if (counter % 2 == 1)
        {
            textComponent.text = "X";
            cells[int.Parse(name)] = 1;
        }
        else
        {
            textComponent.text = "0";
            cells[int.Parse(name)] = 2;
        }

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
