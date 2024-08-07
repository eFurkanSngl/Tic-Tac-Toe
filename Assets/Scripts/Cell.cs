using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cell : MonoBehaviour
{
    public Text label;  // X*O ları tutmak için
    public Button btn;
    public Main main;  // Main Tipinde main değişkeni

    public void Fill()  // Gridi Doldurma 
    {
        btn.interactable = false;  // butonu etkileşime Kapama 

        label.text = main.GetTurnCharacter();
        // hangi harfte diye bakan metodu cağırdık
        // label text olarak atıyoruz
        
        main.Switch();  // değiştirme metodu
    }
    
}
