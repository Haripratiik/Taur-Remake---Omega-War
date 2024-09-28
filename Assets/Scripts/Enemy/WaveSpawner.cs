using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum spawnState { SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int countOfEnemies;
        public float spawnRate;
        public float delay = 0.2f;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public int numberOfEnemies = 2;

    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f;
    public float waveCountDown = 0;

    private spawnState state = spawnState.COUNTING;

    public static bool GameWon;

    public GameManager gameManger;

    // Start is called before the first frame update
    void Start()
    {
        GameWon = false;

        waveCountDown = timeBetweenWaves;

        InvokeRepeating("EnemyIsAlive", 0f, 1f);
        InvokeRepeating("EnemiesLeftCounter", 0f, 1f);

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == spawnState.WAITING)
        {
            //Check if Enemies are still alive
            if (!EnemyIsAlive())
            {
                BeginNewWave();
            }
            else
            {
                return;
            }
        }


        if (waveCountDown <= 0)
        {
            if (state != spawnState.SPAWNING)
            {
                //Start spawining the wave

                StartCoroutine(SpawnWaves(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
        }

    }

    void BeginNewWave ()
    {
        state = spawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            //All waves completed
            GameWon = true;

            gameManger.WinLevel();
            //Debug.Log("ALL WAVES COMPLETED!! Looping...");
        }
        else
        {
            nextWave++;
        }  
    }

    //Change this
    bool EnemyIsAlive()
    {
        List<GameObject> enemiess = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        enemiess.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("BombEnemy")));

        if (enemiess.Capacity == 0)
        {
            return false;
        }

        return true;
    }

    IEnumerator SpawnWaves(Wave _wave)
    {
        Debug.Log("Spawning Wav:" + _wave.name);
        state = spawnState.SPAWNING;

        for (int i = 0; i< _wave.countOfEnemies; i++)
        {
            
            SpawnEnemies(_wave.enemy[Random.Range(0, numberOfEnemies)]);

            yield return new WaitForSeconds(_wave.delay);
        }

        state = spawnState.WAITING;

        yield break;
    }

    void SpawnEnemies (Transform _enemy)
    {
        //Spawn Enemy
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points selected!");
        }

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);

        //Debug.Log("Spawning Enemy:" + _enemy.name);
    }

    void EnemiesLeftCounter ()
    {
        Debug.Log("Enemies Left:" + GameObject.FindGameObjectsWithTag("Enemy").Length);
    }
}
