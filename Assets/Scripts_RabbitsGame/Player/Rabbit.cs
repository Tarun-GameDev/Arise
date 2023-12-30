using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Gender
{
    male,
    female
}

public class Rabbit : MonoBehaviour
{
    public Gender gender = Gender.male;
    public float moveSpeed = 10f;
    public bool dead = false;
    public float health = 100f;
    public float posLimit;  //pos limit so the npcs dont go out of the map
    public Vector3 goalPos;
    public bool available = true;

    public void Move()
    {
        if (dead)
            return;

        RandomlyMove();

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void DealDamage(int _damage)
    {
        health -= _damage;
        if(health <= 0f)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public void Attack()
    {
        
    }

    public void MakeLove()
    {
        
    }

    //Moving Randomly
    public void RandomlyMove()
    {
        float distFromGoal = (goalPos - transform.position).magnitude;

        if (distFromGoal <= .1f)
        {
            SetRandomPoint();
        }
        else
        {
            transform.LookAt(goalPos);
        }
    }


    //Random Position
    public void SetRandomPoint()
    {
        float xPos = Random.Range(-posLimit, posLimit);
        float zpos = Random.Range(-posLimit, posLimit);

        goalPos = new Vector3(xPos, 0f, zpos);
    }
}
