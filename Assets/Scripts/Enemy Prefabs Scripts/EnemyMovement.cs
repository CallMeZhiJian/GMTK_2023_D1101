using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("Reference")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f;

    private Transform target;
    private int pathIndex = 0;
    private Animator anim;

    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
        anim = GetComponent<Animator>();
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

        rb.velocity = direction * moveSpeed;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.CompareTag("Player"))
    //    {
    //        StartCoroutine(DeathAnimation());
    //    }
    //}

    IEnumerator DeathAnimation()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    
}
