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
    public Text Cursor;
    private void Awake()
    {
     board.Build(this);
     // Parametre aldığı için bu sınıfın tipinden burada cağırıyoruz.

     Cursor.text = GetTurnCharacter();
     // Cursoru tutacak prefab in texti Sıraya göre değişecek

    }
    

    public void Switch() // harfleri değiştiren metod
    {
        xTurnCount++; // her sefer bir artmasını istiyorum.
        
        bool hasWinner = board.CheckForWinner(); // board kazananı kontrol ediyorum
        if (hasWinner || xTurnCount == 9)
        {
            // Eğer kazanan var veya sıra 9 sa oyunu bitiryrum
            
            // End Game
            StartCoroutine(EndGame(hasWinner));
            return;
        }
        xTurn = !xTurn;  // Ünlem işareti onu tam tersine çevirir.
        Cursor.text = GetTurnCharacter();

    }

    public string GetTurnCharacter()  // sıra değişme
    {
        if (xTurn) // eğer Xtrun ise x gönder
        {
            return " X ";
        }
        else
        {
            // değilse 0 gönder
            return " O ";
        }
    }

    private IEnumerator EndGame(bool hasWinner)
    {
        Text winnerLabel = Winner.GetComponentInChildren<Text>();
        // WinnerGameObjein chiledının Textini alıyor

        if (hasWinner)
        {
            // Eğer HasWinnersa kazanan yazdırıyorum Sıra kimdeyse onu alıyorum
            winnerLabel.text = GetTurnCharacter() + " " + "Kazanan!";
        }
        else
        {
            // kazanan yoksa berabere yazdırıyorum
            winnerLabel.text = "Berabere";
        }
        // Paneli aktif ediyoruz
        Winner.SetActive(true);
        WaitForSeconds wait = new WaitForSeconds(5.0f);
        yield return wait;
        // daha sonra 5 saniye bekliyr ve reseltliyor tahtayı
        board.Reset();
        xTurnCount = 0; // sayacı sıfırlıyor
        Winner.SetActive(false); // Paneli false ypaıyor
        // Sıfırlama işlemi
        
    }
    
}
