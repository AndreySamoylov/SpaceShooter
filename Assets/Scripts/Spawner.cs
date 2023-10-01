using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float minDelay, maxDelay;//задержка спавна
    public int SpawnLevel;//Уровень Спавна(сложности)
    public GameObject[] enemies;//сслылка на врага
    private Enemy_Casual enemy_Casual;//сслыка на скрипт врага 1
    private Enemy_Casual_Boss enemy_Casual_boss;//сслыка на скрипт врага 2
    private float nextSpawn;//Время следующего спавна
    private int CountSpawn;//Переменная считает сколько было спавнов
    private float nextNeedCount;//Переменная считает сколько нужно ещё спавнов для следующего уровня
    private void Start()
    {
        enemy_Casual = enemies[0].GetComponent<Enemy_Casual>();
        enemy_Casual.health_points = 1;//Здоровье по умолчанию
        enemy_Casual_boss = enemies[1].GetComponent<Enemy_Casual_Boss>();
        enemy_Casual_boss.health_points = 5;//Здоровье по умолчанию
        minDelay = 1.5f;//Значения по умолчанию для задержки
        maxDelay = 3f;
        CountSpawn = 0;
        nextNeedCount = Random.Range(4, 7);
    }
    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        if (Time.time > nextSpawn)
        {
            //случаянная позиция(X) спавна 
            float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Vector2 newPosition = new Vector2(positionX, transform.position.y);
            Instantiate(enemies[0], newPosition, Quaternion.identity); //Создание
            nextSpawn = Time.time + Random.Range(minDelay, maxDelay);//Время следующего спавна
            CountSpawn++;//+1 спавн

            //Переход на следующий уровень, если 
            if (CountSpawn > nextNeedCount)
            {
                SpawnBoss();//Создать босса
                enemy_Casual_boss.health_points += 5;//Увеличить хп босса
                SpawnLevel += 1;//Увеличить уровень спавна
                nextNeedCount += Random.Range(10, 15);//До следующего уровня нужно...
                enemy_Casual.health_points++;//Увеличить хп
                minDelay -= 0.075f; //Уменьшить минимальную задержку спавна
                maxDelay -= 0.075f; //Уменьшить максимальную задержку спавна
                if (minDelay < 0.25f) { minDelay = 0.2f; maxDelay = 0.3f; }//Предел задержки
                Debug.Log("Spawner:Level: " + SpawnLevel);//Вывести сообщение в консоль
            }
        }
    }
    //Создать босса
    private void SpawnBoss()
    {
        float positionX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        Vector2 newPosition = new Vector2(positionX, transform.position.y);
        Instantiate(enemies[1], newPosition, Quaternion.identity); //Создание
        CountSpawn++;//+1 спавн
    }
}
