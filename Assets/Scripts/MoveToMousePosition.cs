using UnityEngine;
using System.Collections;


public class MoveToMousePosition : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float speed = 1.5f;
    private Vector3 target;

    void Start()
    {
        target = transform.position;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = this.transform.position.y;
            target.z = transform.position.z;
        }
        if (animator)   
            animator.SetBool("Walking", (transform.position != target));
        if (spriteRenderer)
            spriteRenderer.flipX = (target - transform.position).x < 0;            
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}