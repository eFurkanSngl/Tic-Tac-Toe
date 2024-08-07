using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Board board;  
    private bool xTurn = true;
    private int xTurnCount = 0; // kaç kere geldiğini hesaplamak için
    
    private void Awake()
    {
     board.Build(this);
     // Parametre aldığı için bu sınıfın tipinden burada cağırıyoruz.
    }

    public void Switch() // harfleri değiştiren metod
    {
        xTurnCount++; // her sefer bir artmasını istiyorum.
        xTurn = !xTurn;  // Ünlem işareti onu tam tersine çevirir.

        bool hasWinner = board.CheckForWinner();
        if (hasWinner)
        {
            Debug.Log("Winneer!!!");
        }
    }

    public string GetTurnCharacter()
    {
        if (xTurn)
        {
            return " X ";
        }
        else
        {
            return " O ";
        }
    }
}
