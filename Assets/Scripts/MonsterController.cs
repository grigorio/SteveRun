using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public float MoveSpeed = 0f;
    Rigidbody2D rigitbody2DMonster;
    // Start is called before the first frame update
    void Start()
    {
        rigitbody2DMonster = GetComponent<Rigidbody2D>();
        rigitbody2DMonster.velocity = new Vector2(-MoveSpeed, rigitbody2DMonster.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
