using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    private Player playerScript;//Ccылка на скрипт Player
    private UI my_UI;//ссылка на скрипт UI

    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        my_UI = GameObject.FindGameObjectWithTag("GameController").GetComponent<UI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Если враг добрался до базы
        if(collision.gameObject.tag == "Enemy")
        {
            playerScript.health_points--;//Уменьшить хп
            my_UI.SetHPtext();//Отобразить хп
            playerScript.IsPlayerBelowZero();//Проверить хп
        }
    }
}
