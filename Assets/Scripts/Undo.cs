using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Undo : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && Cell.lastCell != null)
        {
            int pos = Cell.lastCell.name[0] - '0';
            Cell.cells[pos] = 0;
            Cell.counter--;
            Cell.lastCell.GetComponent<TMP_Text>().text = "";

            Cell.lastCell = null;
        }
    }
}
