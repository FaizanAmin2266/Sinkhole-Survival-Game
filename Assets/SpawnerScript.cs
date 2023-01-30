using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject ItemPrefab;
    public GameObject ItemPrefab2;
    public float spawnRate = 5;
    public float warningTime = 4;
    private float timer = 0;
    public float heightOffset = 3;
    public float widthOffset = 7;
    ScoreLogic scorelog;


    public float timer2 = 0;
    public float detectionTime = 5;
    private GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        scorelog = GameObject.FindGameObjectWithTag("Logic2").GetComponent<ScoreLogic>();
        playerObject = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (scorelog.getAlive() == true)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawnWarning();
                timer = 0;
            }
        }


        

    }

    void spawnWarning()
    {
        float lowestHeight = transform.position.y - heightOffset;
        float highestHeight = transform.position.y + heightOffset;
        float lowestHorizontal = transform.position.x - widthOffset;
        float highestHorizontal = transform.position.x + widthOffset;
        Vector3 pos = new Vector3(Random.Range(lowestHorizontal, highestHorizontal), Random.Range(lowestHeight, highestHeight), 0);
        Instantiate(ItemPrefab2, pos, transform.rotation);
        spawnHole(pos);

    }

    void spawnDeadlyWarning()
    {
        //float lowestHeight = transform.position.y - heightOffset;
        //float highestHeight = transform.position.y + heightOffset;
        //float lowestHorizontal = transform.position.x - widthOffset;
        //float highestHorizontal = transform.position.x + widthOffset;
        Vector3 pos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, 0);
        Instantiate(ItemPrefab2, pos, transform.rotation);
        spawnHole(pos);

    }

    void spawnHole(Vector3 pos)
    {
        
        Instantiate(ItemPrefab, pos, transform.rotation);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (scorelog.getAlive() == true)
        {
            if (timer2 < detectionTime)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                spawnDeadlyWarning();
                timer2 = 0;
            }
        }
    }
}
