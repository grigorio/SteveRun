using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    public GameObject player;

    private float camPlayerOffsetX;

    // Start is called before the first frame update
    void Start()
    {
        camPlayerOffsetX = transform.position.x - player.transform.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x+camPlayerOffsetX, transform.position.y, transform.position.z);
    }   
}
