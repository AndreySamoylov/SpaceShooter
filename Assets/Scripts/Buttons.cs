using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public GameObject canvas_menu;//Панель где находиться кнопка возобновления
    public GameObject button_continie;//Кнопка continue находится в canvas_menu
    private void Start()
    {
        Time.timeScale = 1;//Обновление сцены
    }
    public void Stop()
    {
        //Кнопка остановки времени и активации меню(показа)
        Time.timeScale = 0;
        canvas_menu.SetActive(true);
        button_continie.SetActive(true);
    }
    public void Play()
    {
        //Кнопка возобновление течения времени и деактивации меню
        Time.timeScale = 1;
        canvas_menu.SetActive(false);
        button_continie.SetActive(false);
    }
    //Кнопка начать сначала
    public void Button_Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //кнопка выход
    public void Button_Exit()
    {
        Application.Quit();
    }
}
