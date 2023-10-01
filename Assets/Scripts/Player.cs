using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit
{
    //public static Player playerScrtipt;
    public int MAX_LEVEL = 10;
    public GameObject Menu;//Меню включается при смерти
    public GameObject explosion;//Префаб взрыва
    public GameObject[] lazer_shots;//префабы лазеров
    public Transform lazer_gun_middle;//центральную пушка
    public Transform lazer_gun_left;//левая 1
    public Transform lazer_gun_left_2;//левая 2
    public Transform lazer_gun_left_3;//левая 3
    public Transform lazer_gun_right;//правая
    public Transform lazer_gun_right_2;//правая 2
    public Transform lazer_gun_right_3;//правая 3
    public float speed;//Скорость игрока
    public float delay;//задержка стрельбы

    private UI my_UI;//ссылка на скрипт UI
    private new Rigidbody2D rigidbody;//сслыка на компонент
    private float nextShot;//время когда можно стрелять
    void Awake()
    {
        //playerScrtipt = this;
        my_UI = GameObject.FindGameObjectWithTag("GameController").GetComponent<UI>();
        rigidbody = GetComponent<Rigidbody2D>();
    }       
    private void Update()
    {
        Shot();
        Movement_PC();
        Movement_Android();
    }
    //Метод движения на компьютере
    private void Movement_PC()
    {
        float move_horizontal = Input.GetAxis("Horizontal");//Влево или вправо, -1 ... 1
        float move_vertical = Input.GetAxis("Vertical");//Вниз или Вверх, -1 ... 1
        rigidbody.velocity = new Vector2(move_horizontal, move_vertical) * speed;
    }
    //Управление на андроиде
    private void Movement_Android()
    {
        if(Input.touchCount > 0)
        {
            float step = speed * Time.deltaTime;

            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = Vector2.MoveTowards(transform.position, touchPosition, step);
        }
    }
    //Стрельба - зависит от уровня игрока
    private void Shot()
    {
        if(Time.time > nextShot)
        {
            switch (level)
            {
                case 1:
                    {
                        Instantiate(lazer_shots[0], lazer_gun_middle.position, Quaternion.identity);
                        break; 
                    }
                case 2: {
                        Instantiate(lazer_shots[1], lazer_gun_left.position, Quaternion.identity);
                        Instantiate(lazer_shots[1], lazer_gun_right.position, Quaternion.identity);
                        break; 
                    }
                case 3:
                    {
                        Instantiate(lazer_shots[2], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[2], lazer_gun_left.position, Quaternion.Euler(0, 0, 15));
                        Instantiate(lazer_shots[2], lazer_gun_right.position, Quaternion.Euler(0, 0, -15));
                        break;
                    }
                case 4:
                    {
                        delay = 0.55f;
                        Instantiate(lazer_shots[3], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[3], lazer_gun_left.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[3], lazer_gun_right.position, Quaternion.Euler(0, 0, 0));
                        break;
                    }
                case 5:
                    {
                        delay = 0.55f;
                        Instantiate(lazer_shots[4], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[4], lazer_gun_left.position, Quaternion.Euler(0, 0, 10));
                        Instantiate(lazer_shots[4], lazer_gun_right.position, Quaternion.Euler(0, 0, -10));
                        break;
                    }
                case 6:
                    {
                        delay = 0.55f;
                        Instantiate(lazer_shots[5], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[5], lazer_gun_left.position, Quaternion.Euler(0, 0, 5));
                        Instantiate(lazer_shots[5], lazer_gun_left_2.position, Quaternion.Euler(0, 0, 9));
                        Instantiate(lazer_shots[5], lazer_gun_right.position, Quaternion.Euler(0, 0, -5));
                        Instantiate(lazer_shots[5], lazer_gun_right_2.position, Quaternion.Euler(0, 0, -9));
                        break;
                    }
                case 7:
                    {
                        delay = 0.8f;
                        Instantiate(lazer_shots[6], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[6], lazer_gun_left.position, Quaternion.Euler(0, 0, 5));
                        Instantiate(lazer_shots[6], lazer_gun_left_2.position, Quaternion.Euler(0, 0, 10));
                        Instantiate(lazer_shots[6], lazer_gun_left_3.position, Quaternion.Euler(0, 0, 15));
                        Instantiate(lazer_shots[6], lazer_gun_right.position, Quaternion.Euler(0, 0, -5));
                        Instantiate(lazer_shots[6], lazer_gun_right_2.position, Quaternion.Euler(0, 0, -10));
                        Instantiate(lazer_shots[6], lazer_gun_right_3.position, Quaternion.Euler(0, 0, -15));
                        break;
                    }
                case 8:
                    {
                        delay = 0.7f;
                        Instantiate(lazer_shots[1], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[1], lazer_gun_left.position, Quaternion.Euler(0, 0, 5));
                        Instantiate(lazer_shots[1], lazer_gun_left_2.position, Quaternion.Euler(0, 0, 10));
                        Instantiate(lazer_shots[1], lazer_gun_left_3.position, Quaternion.Euler(0, 0, 15));
                        Instantiate(lazer_shots[1], lazer_gun_right.position, Quaternion.Euler(0, 0, -5));
                        Instantiate(lazer_shots[1], lazer_gun_right_2.position, Quaternion.Euler(0, 0, -10));
                        Instantiate(lazer_shots[1], lazer_gun_right_3.position, Quaternion.Euler(0, 0, -15));
                        break;
                    }
                case 9:
                    {
                        delay = 0.5f;
                        Instantiate(lazer_shots[7], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[7], lazer_gun_left.position, Quaternion.Euler(0, 0, 5));
                        Instantiate(lazer_shots[7], lazer_gun_left_2.position, Quaternion.Euler(0, 0, 10));
                        Instantiate(lazer_shots[7], lazer_gun_left_3.position, Quaternion.Euler(0, 0, 15));
                        Instantiate(lazer_shots[7], lazer_gun_right.position, Quaternion.Euler(0, 0, -5));
                        Instantiate(lazer_shots[7], lazer_gun_right_2.position, Quaternion.Euler(0, 0, -10));
                        Instantiate(lazer_shots[7], lazer_gun_right_3.position, Quaternion.Euler(0, 0, -15));
                        break;
                    }
                default: {
                        delay = 0.3f;
                        Instantiate(lazer_shots[0], lazer_gun_middle.position, Quaternion.Euler(0, 0, 0));
                        Instantiate(lazer_shots[0], lazer_gun_left.position, Quaternion.Euler(0, 0, 5));
                        Instantiate(lazer_shots[0], lazer_gun_left_2.position, Quaternion.Euler(0, 0, 8));
                        Instantiate(lazer_shots[0], lazer_gun_left_3.position, Quaternion.Euler(0, 0, 13));
                        Instantiate(lazer_shots[0], lazer_gun_right.position, Quaternion.Euler(0, 0, -5));
                        Instantiate(lazer_shots[0], lazer_gun_right_2.position, Quaternion.Euler(0, 0, -8));
                        Instantiate(lazer_shots[0], lazer_gun_right_3.position, Quaternion.Euler(0, 0, -13));
                        break; 
                    }
            }
            nextShot = Time.time + delay;
        }
    }
    //Метод проверяет сколько hp, если меньше 1, то уничтожает корабль
    public void IsPlayerBelowZero()
    {
        if(this.health_points < 1)
        {
            Destroy(gameObject); //Уничтожить себя
            Destroy(Instantiate(explosion, transform.position, //Взрыв создать и уничтожить
               Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);
            Menu.SetActive(true);//Активировать меню
            Time.timeScale = 0;//Остановить время
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy"){
            Destroy(collision.gameObject); //Уничтожить того кто столкнулся
            Destroy(Instantiate(explosion, collision.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);
            health_points--; //Отнять хп
            Debug.Log("Health Point:Player:" + health_points);
            IsPlayerBelowZero();
        }
        else if(collision.gameObject.tag == "Enemy_Boss")
        {
            health_points = 0;//Уменьшить хп до 0;
            Debug.Log("Health Point:Player:" + health_points);
            IsPlayerBelowZero();
        }
        else if (collision.gameObject.tag == "Laser_Enemy")
        {
            Destroy(Instantiate(explosion, collision.transform.position,
               Quaternion.Euler(0, 0, Random.Range(0, 360))), 3);//Cоздать взрыв своём месте
            Destroy(collision.gameObject); //Уничтожить того кто столкнулся
            health_points--; //Отнять хп
            Debug.Log("Health Point:Player:" + health_points);
            IsPlayerBelowZero();
        }
        my_UI.SetHPtext();//Отобразить HP
    }
}
