using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public float max_health = 100f;
    public float cur_health = 0f;
    public GameObject healthBar;
    public AudioSource damage_sound;
    public AudioSource die_sound;
    public bool alive;
    public bool sound_on = true;

    private float Damage_Skeleton = 2f;
    private float Damage_Demon = 10f;
    private float Damage_Golem = 10f;
    private float Damage_Guul = 10f;
    private float Damage_Ifrit = 5f;

    void Awake()
    {
        if (damage_sound == null)
        {
            damage_sound = GameObject.Find("Attack").GetComponent<AudioSource>();
        }

        if (die_sound == null)
        {
            die_sound = GameObject.Find("Die").GetComponent<AudioSource>();
        }

    }

    void playHitSound()
    {
        if (sound_on)
        {
            damage_sound.Play();
        }
    }

    void playDieSound()
    {
        if (sound_on)
        {
            die_sound.Play();
        }
    }

    void Start()
    {
        cur_health = max_health;
        print("start Health" + cur_health);
        alive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            playHitSound();
            print("hit");
            takeDamage(5f);
        }
    }

    public void Die()
    {
        playDieSound();
        print("Tower down!:" + cur_health);
        Destroy(gameObject, 1f);
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<Canvas>());
        alive = false;
        cur_health = 0;
    }

    public void takeDamage(float damage)
    {
        print("Take damage:" + damage);

        if (cur_health > 1)
        {
            cur_health -= damage;
            print("cur health:" + cur_health);

            float my_health = cur_health / max_health;

            print("tower new health: " + my_health);
            setHealthBar(my_health);

            if (alive && cur_health <= 1)
            {
                Die();
            }
        }
    }

    public void setHealthBar(float myhealth)
    {
        print("set HealthBar" + myhealth);

        healthBar.transform.localScale = new Vector3(myhealth,
            healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
