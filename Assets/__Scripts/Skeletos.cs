using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletos : Enemy
{
    [Header("Set in Inscpector: Skeletos")]
    public int speed = 2;
    public float timeThinkMin = 1f;
    public float timeThinkMax = 4f;

    [Header("Set Denamically: Skeletos")]
    public int facing = 0;
    public float timeNextDecision = 0;

    private void Update()
    {
        if (Time.time > timeNextDecision) {
            DecideDirection();
        }

        //ѕоле rigid унаследовано от класса Enemy и инициализируетс€ в  Enemy.Awake()
        rigid.velocity = directions[facing]*speed;
    }

    void DecideDirection()
    {
        facing = Random.Range(0, 4);
        timeNextDecision = Time.time + Random.Range(timeThinkMin, timeThinkMax);
    }
}
