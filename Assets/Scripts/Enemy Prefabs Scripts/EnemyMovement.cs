using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D bc;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private Animator anim;
    private bool death;

    private TimeManager timeManager;
    [SerializeField] private AudioClip hitEnemySFX;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
        anim = GetComponent<Animator>();
        timeManager = FindObjectOfType<TimeManager>();
    }

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) < 0.1f)
        {
            pathIndex++;

            if (pathIndex >= LevelManager.main.path.Length)
            {
                StartCoroutine(DeathAnimation());
                //Destroy(gameObject);
                return;
            }
        }

    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        if (death)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = direction * moveSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            death = true;
            SoundManager.instance.PlaySound(hitEnemySFX);
            timeManager.DoSlowMo();
            ScoreSystem.score += 10;
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator DeathAnimation()
    {
        bc.enabled = false;
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
