using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] EnemyPrefab;
    public List<GameObject> boxEnemyList = new List<GameObject>();
    public int enemyBpm = 0;
    double currentTime = 0d;

    TimingManager timingManager;
    NoteGenerator noteGenerator;

    // Start is called before the first frame update
    void Start()
    {
        timingManager = GetComponent<TimingManager>();
        noteGenerator = GameObject.Find("NoteGenerator").GetComponent<NoteGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime;

        enemyAppear();
    }

    void enemyAppear()
    {
        // enemyBpm = noteGenerator.bpm / Random.Range(1, 4);
        
        if (currentTime >= 60d / this.enemyBpm)
        {
            int randomLocation = Random.Range(0, 2);
            int randomEnemy = Random.Range(0, EnemyPrefab.Length);

            if (randomLocation == 0 && randomEnemy != 0)        // bat를 제외한 애들이 오른쪽에서 스폰되는 경우
            {
                GameObject enemyPrefab = Instantiate(EnemyPrefab[randomEnemy]);
                enemyPrefab.GetComponent<EnemyController>().key = -1;

                boxEnemyList.Add(enemyPrefab);
            }
            else if (randomLocation == 0 && randomEnemy == 0)   // bat가 오른쪽에서 스폰되는 경우
            {
                GameObject enemyPrefab = Instantiate(EnemyPrefab[randomEnemy], new Vector3(11, -2, 0), Quaternion.identity);
                enemyPrefab.GetComponent<EnemyController>().key = -1;
                enemyPrefab.GetComponent<Transform>().localScale = new Vector3(-3, 3, 0);

                boxEnemyList.Add(enemyPrefab);
            }
            else if (randomLocation == 1 && randomEnemy != 0)   // bat를 제외한 애들이 왼쪽에서 스폰되는 경우
            {
                GameObject enemyPrefab = Instantiate(EnemyPrefab[randomEnemy], new Vector3(-11, -3.5f, 0), Quaternion.identity);
                enemyPrefab.GetComponent<EnemyController>().key = 1;
                enemyPrefab.GetComponent<Transform>().localScale = new Vector3(-5, 5, 0);

                boxEnemyList.Add(enemyPrefab);
            }
            else                                                // bat가 왼쪽에서 스폰되는 경우
            {
                GameObject enemyPrefab = Instantiate(EnemyPrefab[randomEnemy]);
                enemyPrefab.GetComponent<EnemyController>().key = 1;

                boxEnemyList.Add(enemyPrefab);
            }


            this.currentTime -= 60d / this.enemyBpm;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        /*if (collision.CompareTag("Enemy"))
        {
            Debug.Log("적");
            Destroy(collision.gameObject);
        }*/
    }
}
