using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPatroling : MonoBehaviour
{
    public GameObject[] waypoints;
    private Animator animator;
    private SpriteRenderer sprite;
    private int actualWaypoint;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        animator.SetBool("movingRight", true);

        actualWaypoint = 0;
    }

    void Update()
    {
        Vector2 pos = new Vector2(waypoints[actualWaypoint].transform.position.x, waypoints[actualWaypoint].transform.position.y);
        Vector2 dragonPos = new Vector2(this.transform.position.x, this.transform.position.y);

        if (Vector2.Distance(pos, dragonPos) <= .5f) {
            if (actualWaypoint < waypoints.Length - 1) {
                actualWaypoint++;
                sprite.flipX = !sprite.flipX;
            } else {
                actualWaypoint = 0;
                sprite.flipX = !sprite.flipX;
            }
        }

        transform.position = Vector2.MoveTowards(dragonPos, pos, 0.002f);
    }
}
