using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu_Buttons : MonoBehaviour
{
    //Запустить аркаду - сцену
    public void Button_Arcada()
    {
        SceneManager.LoadScene(1);
    }
    //Выход
    public void Button_Exit()
    {
        Application.Quit();
    }
}
