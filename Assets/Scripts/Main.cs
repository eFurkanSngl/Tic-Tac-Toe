using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Board board;  
    private bool xTurn = true;
    private int xTurnCount = 0; // kaç kere geldiğini hesaplamak için
    public GameObject Winner;
    private void Awake()
    {
     board.Build(this);
     // Parametre aldığı için bu sınıfın tipinden burada cağırıyoruz.
    }
    

    public void Switch() // harfleri değiştiren metod
    {
        xTurnCount++; // her sefer bir artmasını istiyorum.
        
        bool hasWinner = board.CheckForWinner();
        if (hasWinner || xTurnCount == 9)
        {
            // End Game
            StartCoroutine(EndGame(hasWinner));
            return;
        }
        xTurn = !xTurn;  // Ünlem işareti onu tam tersine çevirir.
        
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

    private IEnumerator EndGame(bool hasWinner)
    {
        Text winnerLabel = Winner.GetComponentInChildren<Text>();
        

        if (hasWinner)
        {
            winnerLabel.text = GetTurnCharacter() + " " + "Kazannn...";
        }
        else
        {
            winnerLabel.text = "Berabere";
        }

        Winner.SetActive(true);
        WaitForSeconds wait = new WaitForSeconds(5.0f);
        yield return wait;
        
        board.Reset();
        xTurnCount = 0;
        Winner.SetActive(false);
        // Sıfırlama işlemi
        
    }
    
}
