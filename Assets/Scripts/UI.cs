using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI HealthPoints_Text;//Ссылка на текст
    public TextMeshProUGUI Level_Text;//Ссылка на текст
    public TextMeshProUGUI Damage_Text;//Ссылка на текст

    private GameObject player;//Ccылка на объект player
    private Player playerScript;//Ccылка на скрипт Player
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();

        SetHPtext();
        SetLeveLtext();
        SetDamageText();
    }
    //Отображать разные тесты
    public void SetHPtext(){ HealthPoints_Text.text = "HP:" + playerScript.health_points;}
    public void SetLeveLtext() {
        if (playerScript.level >= 8) {
            Level_Text.text = "Level:MAX";
        }
        else 
        {
            Level_Text.text = "Level:" + playerScript.level;
        }
    }
    public void SetDamageText() { Damage_Text.text = "Damage:" + playerScript.damage; }
}
