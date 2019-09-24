using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    //public GameObject enemy1;
    //public GameObject enemy2;

    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        //int enemyindex = Random.Range(0,3);

        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        /*
        if (enemyindex == 1)
        {

        }
        else if (enemyindex == 2)
        {
            Instantiate(enemy1, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        }
        else
        {
            Instantiate(enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        }
        */
    }
}
