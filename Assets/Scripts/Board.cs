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

  public bool CheckForWinner()
  {
    int i = 0;
    for(i = 0; i<=6;i+=3)
    {
      if (!CheckValues(i,i+1))
      {
        continue;
      }

      if (!CheckValues(i,i+2))
      {
        continue;
      }
      return true;
    }

    for (i = 0; i <= 2; i++)
    {
      if (!CheckValues(i,i+3))
      {
        continue;
      }

      if (!CheckValues(i,i+6))
      {
        continue;
      }

      return true;
    }
    
    return false;
  }

  public bool CheckValues(int firstIndex, int secondIndex)
  {
    string firstValue = _cells[firstIndex].label.text;
    string secondValue = _cells[secondIndex].label.text;

    if (firstValue == "" || secondValue == "" )
    {
      return false;
    }

    if (firstValue == secondValue)
    {
      return true;
    }
    else
    {
      return false; 
    }
    
  }
}
