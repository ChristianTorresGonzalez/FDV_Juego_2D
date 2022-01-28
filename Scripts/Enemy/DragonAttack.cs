using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAttack : MonoBehaviour
{
    private GameObject player;
    private Animator animator;
    public GameObject bala;
    public float shootDelay;
    private float lastShoot;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animator = GetComponent<Animator>();
        shootDelay = .5f;
    }

    void Update()
    {
        if (GetComponent<DragonLife>().GetDragonAlive() && !GetComponent<DragonLife>().GetDragonDizzy()) {
            if (player.GetComponent<PlayerLife>().GetPlayerAlive()) {
                if ((Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(this.transform.position.x, this.transform.position.y)) <= 5f) && Time.time > lastShoot + shootDelay) {
                    lastShoot = Time.time;
                    animator.SetBool("dragonAttacking", true);
                    ShootDragonBullet();
                } else {
                    animator.SetBool("dragonAttacking", false);
                }
            }
        }
    }

    private void ShootDragonBullet()
    {
        Vector2 enemyPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 direction = (new Vector2(this.transform.position.x, this.transform.position.y) - enemyPosition).normalized;
        enemyPosition = enemyPosition + direction * (-100);

        GameObject bullet = Instantiate(bala, new Vector2(this.transform.position.x, this.transform.position.y) + (direction * (-1.05f)), Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetOrientation(enemyPosition);
        bullet.GetComponent<BulletScript>().ShootBullet();
    }
}
