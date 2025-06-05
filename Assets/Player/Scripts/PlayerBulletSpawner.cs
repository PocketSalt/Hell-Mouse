using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBulletSpawner : MonoBehaviour
{
    // Bullet attributes is determined by player stats
    public GameObject bullet;

    // default values for now
    private float m_bulletLife = 3f;
    private float m_speed = 7f;
    private float m_rate = 0.2f;

    private GameObject m_spawnedBullet;
    private float timer = 0f;
    private bool m_canShoot = false;

    private void Start()
    {
        // set timer to fire rate so it immediately is ready
        timer = m_rate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (m_canShoot)
        {
            if (Input.GetButton("Fire1"))
            {   
                Fire();
                timer = 0f;
            }
        }

        m_canShoot = (timer >= m_rate);
    }

    private void Fire()
    {
        if (bullet)
        {
            m_spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            m_spawnedBullet.GetComponent<Bullet>().speed = m_speed;
            m_spawnedBullet.GetComponent<Bullet>().bulletLife = m_bulletLife;
            m_spawnedBullet.transform.rotation = transform.rotation;
        }
    }
}
