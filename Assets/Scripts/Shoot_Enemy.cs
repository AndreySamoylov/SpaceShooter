using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Enemy : MonoBehaviour
{
    public float direction;//полет лазера: -1 - вниз, +1 - вверх
    public float speed;
    private new Rigidbody2D rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //transform.rotation.z управляет движением лазера таким образом, 
        //что он летит туда куда его повернут
        rigidbody.velocity = new Vector2(transform.rotation.z, direction) * speed;
    }
}