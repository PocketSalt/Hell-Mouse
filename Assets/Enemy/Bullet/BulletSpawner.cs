using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // add more if you want :)
    enum SpawnerType
    {
        STRAIGHT,
        SPIN,
        TARGET
    }

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType m_spawnerType;
    [SerializeField] private float m_firingRate = 1f;
    [SerializeField] private float m_spinSpeed = 0.5f;

    // private stuff
    private GameObject m_target;
    private Vector3 m_angle;

    private GameObject m_spawnedBullet;
    private float timer = 0f;

    private void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (m_spawnerType == SpawnerType.SPIN)
            transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + m_spinSpeed);

        if (m_spawnerType == SpawnerType.TARGET)
        {
            Quaternion targetRotation = GetTargetAngle(m_target);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 100 * Time.deltaTime);
        }

        if (timer >= m_firingRate)
        {
            Fire();
            timer = 0f;
        }
    }

    private void Fire()
    {
        if (bullet)
        {
            m_spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            m_spawnedBullet.GetComponent<Bullet>().speed = speed;
            m_spawnedBullet.GetComponent<Bullet>().bulletLife = bulletLife;
            m_spawnedBullet.transform.rotation = transform.rotation;
        }
    }

    private Quaternion GetTargetAngle(GameObject target)
    {
        // calculate the angle from my position, to target position.
        Vector3 direction = target.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle);
    }
}
