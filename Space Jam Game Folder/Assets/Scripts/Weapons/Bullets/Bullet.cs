﻿using System.Collections;
using UnityEngine;
using Resources;

public class Bullet : MonoBehaviour
{
    public static Bullet I { get; private set; }

    public bool isEnemy;

    [SerializeField] protected float lifeTime;

    [HideInInspector] public bool isShotgun;
    [HideInInspector] public int damage;

    [HideInInspector] public float speed;
    [HideInInspector] public Vector3 scale;

    private void Start() => transform.localScale = scale;

    private void Update()
    {
        if (!isShotgun) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        StartCoroutine(DestroyBulletOnTimer(lifeTime));
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.CompareTag("Bullets") && !other.CompareTag("Explosion") && !other.CompareTag("Ex Bullets")) {
            if (!isEnemy) {
                if (!other.CompareTag("Player")) {
                    Destroy(gameObject);
                }
            }
            else {
                if (!other.CompareTag("Enemy")) {
                    Destroy(gameObject);
                }

                if (other.CompareTag("Player")) {
                    Player.I.TakeDamage(damage);
                }
            }
        }
    }

    protected IEnumerator DestroyBulletOnTimer(float timer) {
        yield return new WaitForSeconds(timer);

        Destroy(gameObject);
    }
}
