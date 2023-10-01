using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background_Music_Controller : MonoBehaviour
{
    public AudioClip[] clips;//Треки
    private int id;//Индект нужного трека из массива
    private AudioSource AudioSource;//Ссылка на компонент
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        id = Random.Range(0, clips.Length);//Случаяный трек
        AudioSource.clip = clips[id];//Поставить трек
        AudioSource.Play();
    }
    private void Update()
    {
        Is_Playing();
    }
    //Определяет играет ли что-нибудь, если нет ставит следующий трек
    private void Is_Playing()
    {
        if (!AudioSource.isPlaying)
        {
            id++;//Cледующий трек
            //Чтобы треки менялись по кругу
            if (id > clips.Length) { id = 0; }
            AudioSource.clip = clips[id];//Поставить трек
            AudioSource.Play();
        }
    }
    //Кнопка: сменить трек
    public void Button_Music_Next()
    {     
        id++;//Cледующий трек
             //Чтобы треки менялись по кругу
         if (id > clips.Length) { id = 0; }
        AudioSource.clip = clips[id];//Поставить трек
        AudioSource.Play();
    }
}
