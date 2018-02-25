using UnityEngine;
using System.Collections;


public class MoveToMousePosition : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float speed = 1.5f;
    private Vector3 target;
    private RaycastHit2D hit;

    void Start()
    {
        target = transform.position;
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (DialogueManager.instance.Busy)
            return;
        // Moves towards a position
        if (Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(target, Vector2.zero);
            target.y = this.transform.position.y;
            target.z = transform.position.z;            
        }

        if (hit.collider != null)
        {
            float distance = Mathf.Abs((target - transform.position).x);
            GameObject targetObject = hit.collider.gameObject;

            // Close to interact
            if (distance < 10.0f)
            {
                hit = new RaycastHit2D();
                InteractWithNPC(targetObject);
                target = this.transform.position;                
            }
        }
        if (animator)   
            animator.SetBool("Walking", (transform.position != target));
        if (spriteRenderer)
            spriteRenderer.flipX = (target - transform.position).x < 0;
        MoveTo(target);        
    }

    void MoveTo(Vector3 target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void InteractWithNPC(GameObject NPC)
    {
        NPC.GetComponent<FloatingDialog>().StartDialog();
    }    
}