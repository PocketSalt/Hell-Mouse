using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public enum EnemyState
{
    ALIVE,
    DEAD
}

public class EnemyStats : MonoBehaviour
{
    public int HP;
    public EnemyState State;
    [SerializeField] private ParticleSystem death;

    private bool isDying = false;

    private void Start()
    {
        State = EnemyState.ALIVE;
    }

    private void Update()
    {
        if (HP <= 0)
            State = EnemyState.DEAD;

        if (State == EnemyState.DEAD && isDying == false)
            StartCoroutine(Die());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // check if tag == Attack
        if (collision.tag == "PlayerAttack")
        {
            HP -= 1;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Die()
    {
        isDying = true;
        GetComponent<SpriteRenderer>().enabled = false;
        death.Play();
        yield return new WaitForSeconds(0.3f);
        death.Stop();
        Destroy(this.gameObject);
    }
}
