using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background_Scroller : MonoBehaviour
{
    public Sprite[] images;//изображения фона
    public Image[] background;//Ссылки на фоны 
    public float speed;//Скорость перемещения фона
    Vector2 start_position;//Начальное положение фона
    // Start is called before the first frame update
    void Start()
    {
        //случаяное числа между количеством изображений фона
        int image_choice = Random.Range(0, images.Length);
        //Поставка в backround случаяное изображение фона
        background[0].sprite = images[image_choice];
        background[1].sprite = images[image_choice];
        //Присваивание текущего положения
        start_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 0 ... 20, с течением времени в зависимости от speed
        float movement = Mathf.Repeat(Time.time * speed, 10);
        transform.position = start_position + Vector2.down * movement;
    }
}
