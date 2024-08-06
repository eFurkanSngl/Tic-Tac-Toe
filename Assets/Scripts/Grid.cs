using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
  public GameObject CellPrefab;  // prefabı tutacak field
  private Cell[] _cells = new Cell[9]; // bir array oluşturduk ve 9 eleman alacak dedik

  private void Start()
  {
    Build();
  }

  private void Build()
  {
    for (int i = 0; i < _cells.Length; i++)
    {
      GameObject newCell = Instantiate(CellPrefab, transform);
      _cells[i] = newCell.GetComponent<Cell>();
    }
  }

}
