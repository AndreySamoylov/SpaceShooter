using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Casual_Boss : Unit
{
    public GameObject[] bonuses;//Префабы бонусов
    public GameObject explosion;//Префаб взрыва
    public GameObject explosionBoss;//Префаб взрыва босса
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
    private float nextShot;//время когда можно стрелять
    [SerializeField] private int roll;//Переменная нужна для генераций случаянностей
    private void Start()
    {
        MaxHealthPoints = health_points;
        HealthBarScript = HealthBar.GetComponent<HealthBar>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        scoreScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreScript>();
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = Vector2.down * Random.Range(minSpeed, maxSpeed);//Запустить корабль
        roll = Random.Range(0, 100);//Генерация случаяного числа
        nextShot = Time.time + Random.Range(minDelay, maxDelay);
    }
    // Update is called once per frame
    private void Update()
    {
        Shoot();
    }
    //Стреляет, один раз
    private void Shoot()
    {
        if (Time.time > nextShot) 
        {
            Instantiate(shots[0], lazer_gun_middle.position, Quaternion.identity);
            Instantiate(shots[0], lazer_gun_left_2.position, Quaternion.Euler(0, 0, -20));
            Instantiate(shots[0], lazer_gun_right_2.position, Quaternion.Euler(0, 0, 20));
            nextShot +=Random.Range(minDelay, maxDelay);
        }
    }
    //Уничтожение босса, где points-кол-во очков за уничтожение
    private void IsEnemyHpBelowZero(int points)
    {
        if (health_points <= 0)
        {
            //Создание взрыва и его уничтожение через 3 сек
            Destroy(Instantiate(explosionBoss, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);
            Destroy(gameObject);//Уничтожение себя
            scoreScript.score += points;//Увеличение счёта
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
            Destroy(Instantiate(explosion, collision.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);
            Destroy(collision.gameObject);//Уничтожение с кем столкнулся
            health_points -= playerScript.damage;
            //Уменьшить значение полоски жизней
            float percentHealthPoint = ((100 * health_points) / MaxHealthPoints);//Процент ХП от максимума
            HealthBarScript.UpdateSlider((int)percentHealthPoint);
            IsEnemyHpBelowZero(1000);
        }
    }
    //Метод спавнит или не спавнит бонус после уничтожения корабля
    private void IsBonus()
    {
        //33% bonus level, 66% bonus damage up
        if(roll >= 0 && 66 > roll)
        {
            Instantiate(bonuses[1], transform.position, Quaternion.Euler(0, 0, 0));
        }
        else if(roll >= 66 && 100 >= roll)
        {
            Instantiate(bonuses[0], transform.position, Quaternion.Euler(0, 0, 0));
        }
    }
}
