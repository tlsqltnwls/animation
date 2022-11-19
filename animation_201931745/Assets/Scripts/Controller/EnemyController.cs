using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   

    public float moveSpeed = 0.0f;
    public int key = -1; // 방향

    float animTime;
    float hitCondition; // 플레이어 위치 - enemyPrefab 위치

    Animator animator;
    TimingManager timingManager;
    GameObject player;
    EnemyGenerator enemy;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        // 애니메이션 재생 시간
        timingManager = GameObject.Find("NoteGenerator").GetComponent<TimingManager>();
        player = GameObject.Find("Player");
        enemy = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
    }


    // Update is called once per frame
    void Update()
    {
        // deltaTime * noteSpeed 값으로 x 좌표 이동시켜줌 
        transform.Translate(moveSpeed * Time.deltaTime * key, 0, 0);

    }

    
    void Dead()
    {
        moveSpeed = 0.0f;
        Debug.Log("꽥");
        animator.SetTrigger("Dead");

        enemy.boxEnemyList.Remove(gameObject);
        Destroy(gameObject, animTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Dead();
        }

        for (int i = 0; i < enemy.boxEnemyList.Count; i++)
        {
            if (collision.gameObject.tag == "DeadLine" && timingManager.hit)
                {
                hitCondition = player.transform.localPosition.x - enemy.boxEnemyList[i].transform.localPosition.x;

                if (player.GetComponent<PlayerController>().key > 0 && hitCondition > 0)
                // 플레이어가 왼쪽 보고 있고, 적이 플레이어의 왼쪽에 있을 경우
                {
                    Dead();
                }
                else if (player.GetComponent<PlayerController>().key < 0 && hitCondition < 0)
                // 플레이어가 오른쪽 보고 있고, 적이 플레이어의 오른쪽에 있을 경우
                {
                    Dead();
                }

            }          
        }

    }
}
