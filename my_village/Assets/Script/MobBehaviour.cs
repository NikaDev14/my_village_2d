using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehaviour : MonoBehaviour
{
    public Transform[] pathPoints;
    Vector2 dir;
    public float speed;
    public SpriteRenderer sr;

    void Start()
    {
        dir = Vector2.right;           
    }

    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position.x > pathPoints[1].position.x)
        {
            dir = Vector2.left;
            sr.flipX = true;
        }
        if (transform.position.x < pathPoints[0].position.x)
        {
            dir = Vector2.right;
            sr.flipX = false;
        }
    }

}
