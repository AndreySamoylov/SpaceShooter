using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy_Casual : Unit
{
    public GameObject[] bonuses;//Префабы бонусов
    public GameObject explosion;//Префаб взрыва
    public GameObject[] shots;//префабы выстрелов
    public GameObject HealthBar;//Полоска жизней
    private HealthBar HealthBarScript;//Ссылка на скрипт полоски жизней
    private float MaxHealthPoints;//Сколько хп при появлении (макс)
    public float minDelay, maxDelay;//задержка выстрела
    public float minSpeed, maxSpeed;//макс и мин скорость
    public Transform lazer_gun_middle;//центральную пушка
    public Transform lazer_gun_left;//левая 1
    public Transform lazer_gun_left_2;//левая 2
    public Transform lazer_gun_right;//правая
    public Transform lazer_gun_right_2;//правая 2

    private Player playerScript;//Ccсылка на скрипт
    private ScoreScript scoreScript;//ссылка на скрипт 
    private new Rigidbody2D rigidbody;
    private bool wasShoot = false;//переменная проверяющая был ли выстрел
    private bool IsShootedEnemy;//переменная определяющая может ли этот корабль стрелять
    private float timeSpawned;//переменная времени спавна
    [SerializeField] private int roll;//Переменная нужна для генераций случаянностей
    private void Start()
    {
        MaxHealthPoints = health_points;
        HealthBarScript = HealthBar.GetComponent<HealthBar>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        scoreScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreScript>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.down * Random.Range(minSpeed, maxSpeed);//Запустить корабль
        timeSpawned = Time.time;//Определение времени спавна
        roll = Random.Range(0, 100);//Генерация случаяного значения
        IsShootedShip(30);//Будет ли корабль стрелять
    }
    // Update is called once per frame
    private void Update()
    {
        Shoot();
    }
    //Стреляет, один раз
    private void Shoot()
    {
        if (Time.time > timeSpawned + Random.Range(minDelay, maxDelay) && !wasShoot && IsShootedEnemy)
        {
            Instantiate(shots[0], lazer_gun_middle.position, Quaternion.identity);
            wasShoot = true;
        }
    }
    //Будет ли этот корабль стрелять - probabity(%)(<=100) вероятность, что будет стрелять 
    private void IsShootedShip(int probabity)
    {
        int digits = Random.Range(0, 100);
        if(digits <= probabity)//30% что корабль будет стрелять
        { IsShootedEnemy = true;}
        else
        { IsShootedEnemy = false; }
    }
    //Проверяет меньше 0 ли хп и если меньше уничтожает себя
    private void IsEnemyHpBelowZero()
    {
        if(health_points <= 0)
        {
            //Создание взрыва и его уничтожение через 3 сек
            Destroy(Instantiate(explosion,transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);
            Destroy(gameObject);//Уничтожение себя
            scoreScript.score += 50;//Увеличение счёта
            scoreScript.SetScoreText();//Отобразить рекорд
            scoreScript.SetHighScore();//Запомнить максимальный рекорд
            scoreScript.SetHighScoreText();//Отобразить максимальный рекорд
            IsBonus();//Спавн или не спавн бонуса
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //Создание взрыва и его уничтожение через 3 сек
            Destroy(Instantiate(explosion,collision.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);
            Destroy(collision.gameObject);//Уничтожение с кем столкнулся
            health_points -= playerScript.damage;
            //Уменьшить значение полоски жизней
            float percentHealthPoint = ((100 * health_points) / MaxHealthPoints);//Процент ХП от максимума
            HealthBarScript.UpdateSlider((int)percentHealthPoint);
            IsEnemyHpBelowZero();
        }
    }
   //Метод спавнит или не спавнит бонус после уничтожения корабля
   private void IsBonus()
    {
        if(roll >= 90&& roll <= 100)
        {
            Instantiate(bonuses[1], transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
