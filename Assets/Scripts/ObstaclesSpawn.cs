using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstaclesSpawn : MonoBehaviour
{
    // declaring array of obstacles object
    public GameObject[] Obstacles;
    public float xPos;
    public float zPos;
    public float yPos;
    public int ObstaclesCount;
    private int obsType;
    private int spellType;
    // declared instance of the player 
    public Transform Player;
    private GameObject temp;
    private GameObject spell_temp;
    // declared instance of CountdownManager script
    private CountDownManager stm;
    private int count = 5; // number of prefabs
    private int no_obstacles = 0;
    // declared instance of PlayerCollision script
    // we don't want the obstaclese to spawn after the player is dead
    private PlayerCollision collide;
    private List<GameObject> activeObstacles;
    void Start()
    {
        activeObstacles = new List<GameObject>();
        stm = GameObject.Find("Canvas").GetComponent<CountDownManager>();
        collide = GameObject.Find("Player").GetComponent<PlayerCollision>();
        StartCoroutine(ObstacleRandomize());
        

    }
    private void Update()
    {
        if (collide.isDead == true)
        {

           Invoke("RemoveObstacle",1.5f);
        }
    }
   
    IEnumerator ObstacleRandomize()
    {


        while (collide.isDead == false)
        {
            // randomized the postion of the spawned obstacles

           
            zPos = Random.Range(Player.position.z + 28.0f, Player.position.z + 35.0f);
           
            obsType = Random.Range(0, count);
            
            temp = Obstacles[obsType];

            if (obsType == 3)
            {
                xPos = 0.0f;
                yPos = 0.5f;
                SpawnObject(temp);
            }
            if (obsType == 2)
            {
                if (Random.Range(0, 2) == 1)
                {
                    xPos = -0.42f;
                }
                else
                {
                    xPos = 0.42f;
                }

                yPos = 1.25f;
                SpawnObject(temp);
            }

            if (obsType == 4)
            {
                xPos = -0.11f;
                yPos = 0.55f;
                SpawnObject(temp);
            }
            if (obsType == 0)
            {
                xPos = Random.Range(-4.60f, -1.33f);
                yPos = -2.42f;
                SpawnObject(temp);

            }
            if (no_obstacles >= 10 && obsType > 4)
            { 
                if (obsType == 5)
                {
                    xPos = Random.Range(-1.12f, 2.02f);
                    yPos = Random.Range(0.26f, 0.5f);
                    SpawnObject(temp);
                    no_obstacles = 0;
                    count = 5;

                }
                if (obsType == 6)
                {

                    xPos = Random.Range(-1.0f, 2.01f);
                    yPos = Random.Range(0.17f, 0.25f);
                    SpawnObject(temp);
                    count = 5;
                    no_obstacles = 0;
                }
                if(obsType == 7)
                {

                    xPos = Random.Range(-1.1f, 2.01f);
                    yPos = Random.Range(0.27f, 0.45f);
                    SpawnObject(temp);
                    count = 5;
                    no_obstacles = 0;
                }
            
            }

            if(obsType == 1)
            {
                yPos = 3.0f;
                xPos = Random.Range(-1.21f, -1.07f);
                SpawnObject(temp);
               
            }

            ObstaclesCount += 1;
           
            no_obstacles += 1;
            if (no_obstacles == 10)
            {
                count = 8;
            }
            
            //  Destroy(this.gameObject, 5.0f);

            if (Player.position.z > 300.0f)
            {
                yield return new WaitForSeconds(0.95f);

            }
            else
            {
                yield return new WaitForSeconds(1.2f);

            }

            

            
        }
    }
    void SpawnObject(GameObject tempObstacle)
    {
        // objexts are not spawned after the player is dead;
        if (collide.isDead)
        {
            return;
        }
        // instantiate the object only after the countdown is completed
        if (stm.countDownCompleted == true)
        {
            GameObject go;
            go = Instantiate(tempObstacle, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            go.transform.SetParent(transform);
            activeObstacles.Add(go);

            if (activeObstacles.Count > 10)
            {
                RemoveObstacle();
            }

        }

    }

    void RemoveObstacle()
    {
        int i = 0;
        if (collide.isDead == true)
        {
            for (i = 0; i < activeObstacles.Count; i++)
            {
                Destroy(activeObstacles[i]);
                activeObstacles.RemoveAt(i);

            }

        }
        else
        {
            for (i = 0; i < 4; i++)
            {
                Destroy(activeObstacles[i]);
                activeObstacles.RemoveAt(i);

            }

        }
      
    }

}

