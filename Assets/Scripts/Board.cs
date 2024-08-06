using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
  public GameObject CellPrefab;  // prefabı tutacak field
  private Cell[] _cells = new Cell[9]; // bir array oluşturduk ve 9 eleman alacak dedik
  
  
  public void Build(Main main)  // Main class tipinde bir tane param alyıro
  {
    for (int i = 0; i < _cells.Length; i++)
     // burada cells elemanı kadar dönüyor 
    {
      GameObject newCell = Instantiate(CellPrefab, transform);
      // Burada Yaratıyoruz.
      _cells[i] = newCell.GetComponent<Cell>();
      // burada cells fordan dönen elemanlarına newcell de Compenenti Cell olanları atıyor.
      _cells[i].main = main;
    }
  }

}
