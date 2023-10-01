using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public bool isHealth, isLevel, isDamage;//Что бонус будет увеличивать
    public float speed;//Скорость движения бонуса
    public GameObject sound;//Ccылка на префаб звук
    private GameObject player;//Ccылка на объект player
    private Player playerScript;//Ccылка на скрипт Player
    private UI my_UI;//ссылка на скрипт UI
    private Rigidbody2D rb;//ccылка на компонет Rigidbody2D
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
        my_UI = GameObject.FindGameObjectWithTag("GameController").GetComponent<UI>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1) * speed;//Движение вниз
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);//Уничтожить себя
            //Смотря какая переменная включена от того зависит бонус
            if (isHealth)
            {
                playerScript.health_points++; Debug.Log("Player:HP:" + playerScript.health_points);
                my_UI.SetHPtext();
            }
            else if (isLevel)
            {
                //Если Уровень уже максимальный увеличить урон
                if (playerScript.MAX_LEVEL != playerScript.level)
                {
                    playerScript.level++; Debug.Log("Player:Level:" + playerScript.level);
                }
                else{playerScript.damage++; Debug.Log("Player:Damage:" + playerScript.damage);
                }
                my_UI.SetLeveLtext();
            }
            else if (isDamage)
            {
                playerScript.damage++; Debug.Log("Player:Damage:" + playerScript.damage);
                my_UI.SetDamageText();
            }
            Destroy(Instantiate(sound, transform.position, Quaternion.Euler(0, 0, 0)), 2);//Создать и уничтожить звук
            //Destroy(gameObject);//Уничтожить себя
        }
    }
}
