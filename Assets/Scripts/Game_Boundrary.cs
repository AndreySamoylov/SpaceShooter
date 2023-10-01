using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Boundrary : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Метод убирает объект, который вызодит за пределы границы
        Destroy(collision.gameObject);
    }
}
