using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController  : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    Rigidbody2D rigitbody2DComp;
    private bool isGrounded = false;

    public GameObject GameOver;

    [SerializeField]
    WorldManager worldManager;

    [SerializeField]
    private float jumpSpeed = 5.0f;


    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigitbody2DComp = GetComponent<Rigidbody2D>();
        rigitbody2DComp.velocity = new Vector2(MoveSpeed, rigitbody2DComp.velocity.y);
        animator = GetComponent <Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded)
        {
            Run();
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            isGrounded = false;

        }
    }

    private void Run()
    {
        rigitbody2DComp.velocity = new Vector2(MoveSpeed, rigitbody2DComp.velocity.y);
        animator.Play("Run");
    }

    private void Jump()
    {
        animator.Play("jump");
        rigitbody2DComp.velocity = new Vector2(rigitbody2DComp.velocity.x, jumpSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collObj = collision.gameObject;
        string collObjName = collObj.name;
        if (collObjName.StartsWith("Ground"))
        {
            worldManager.OnHitGround(collObj);
            isGrounded = true;
            
        }
        if (collObjName.StartsWith("Creeper") || collObjName.StartsWith("ghost"))
        {
            isGrounded = false;
            animator.Play("death");
            print("STOLKNULSYA s CREEPERom");
            MoveSpeed = 0;
            GameOver.SetActive(true);
            
        }
    }
}
