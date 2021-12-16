using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldManager : MonoBehaviour
{


    [SerializeField]
    private GameObject[] grounds;

    private Vector3 groundSize;

    private int currentGroundIndex = 0;
  

    public Transform SpawnPos;
    public Transform playerPos;
    public GameObject[] monsters;
    public float TimeSpawn;

    // Start is called before the first frame update
    void Start()
    {
        groundSize = grounds[0].GetComponent<SpriteRenderer>().bounds.size;

        for(int i=1; i<grounds.Length; i++)
        {
            GameObject prevGround = grounds[i - 1];
            GameObject curGround = grounds[i];
            Vector3 prevGroundPos = prevGround.transform.position;
            curGround.transform.position = new Vector3(
                prevGroundPos.x + groundSize.x,
                prevGroundPos.y ,
                prevGroundPos.z
                );
        }
        StartCoroutine(SpawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Repeat()
    {
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {

        SpawnPos.position = new Vector3(playerPos.position.x + 30, playerPos.position.y, playerPos.position.z);
        int rndm = UnityEngine.Random.Range(0, 1);
        print(rndm);
        int rndm2 = UnityEngine.Random.Range(0, 3);
        print(rndm2);

        yield return new WaitForSeconds(TimeSpawn);
        Instantiate(monsters[rndm], SpawnPos.position, Quaternion.identity);
       
        Repeat();
       
    }

    public void OnHitGround(GameObject currentGround)
    {

        int index = Array.IndexOf(grounds, currentGround);
        if (index < 0)
        {
            return;
        }
        if (currentGroundIndex == index)
        {
            return;

        }
        currentGroundIndex = index;
        UpdateGroundPos(currentGroundIndex);

    }


    private void UpdateGroundPos(int groundIndex)
    {
        int prev2Index = groundIndex - 2;
        if (prev2Index < 0)
        {
            prev2Index += grounds.Length;
        }
        int nextIndex = (groundIndex + 1) % grounds.Length;

        Vector3 groundPos = grounds[nextIndex].transform.position;
        if (grounds[prev2Index].transform.position.x < groundPos.x)
        {
            grounds[prev2Index].transform.position = new Vector3(

                groundPos.x + groundSize.x,
                groundPos.y,
                groundPos.z
                );
        }
    }
}
