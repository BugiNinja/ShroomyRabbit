using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int initialHp = 50; //Starting HitPoints

    public int maxHp = 500; //Max amount of HitPoints

    public float knockback = 200; //Knockback force when hit

    public float invisibleTime = 1; //Invisible time when hit

    bool alive = true;

    bool invisible = false;

    float invisibleTimer;

    public int hp;

    public bool playerShroomed;

    public bool enemyShroomed;

    public Sprite powerPlayer;

    public Sprite powerEnemy;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        hp = initialHp;

        playerShroomed = false;

        enemyShroomed = false;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (invisible)
        {
            InvicibilityTimer();
        }
        if (playerShroomed == true)
        {
            spriteRenderer.sprite = powerPlayer;
        }
        if (enemyShroomed == true)
        {
            spriteRenderer.sprite = powerEnemy;
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
        if (hp >= 200)
        {
            playerShroomed = true;
            enemyShroomed = true;
        }
        else if (hp < 200)
        {
            playerShroomed = false;
            enemyShroomed = false;
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
