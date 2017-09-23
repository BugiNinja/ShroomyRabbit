using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int initialHp = 100; //Starting HitPoints

    public int maxHp = 100; //Max amount of HitPoints

    public float knockback = 200; //Knockback force when hit

    public float invisibleTime = 1; //Invisible time when hit

    bool alive = true;

    bool invisible = false;

    float invisibleTimer;

    public int hp;

    void Start()
    {
        hp = initialHp;
    }

    void Update()
    {
        if (invisible)
        {
            InvicibilityTimer();
        }
    }


    public void AddLife(int amount) 
    {
        hp += amount;
        CheckLife();
    }
    public void LoseLife(int amount)
    {
        hp -= amount;
        CheckLife();
    }
    public void ResetLife()
    {
        hp = initialHp;
    }
    public int GetALife()
    {
        return hp;
    }
    private void CheckLife()
    {
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        else if (hp <= 0)
        {
            alive = false;
        }
    }


    public float GetKnockback()
    {
        return knockback;
    }
    public void GiveInvicibility()
    {
        invisible = true;
        invisibleTimer = invisibleTime;
    }
    public bool IsInvicible()
    {
        return invisible;
    }
    private void InvicibilityTimer()
    {
        if (invisibleTimer > 0)
        {
            invisibleTimer -= Time.deltaTime;
            
        }
        else if(invisibleTimer <= 0)
        {
            invisible = false;
        }
    }
    

    public bool IsAlive()
    {
        return alive;
    }


}
