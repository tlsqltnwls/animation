using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   

    public float moveSpeed = 0.0f;
    public int key = -1; // ����

    float animTime;
    float hitCondition; // �÷��̾� ��ġ - enemyPrefab ��ġ

    Animator animator;
    TimingManager timingManager;
    GameObject player;
    EnemyGenerator enemy;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        animTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        // �ִϸ��̼� ��� �ð�
        timingManager = GameObject.Find("NoteGenerator").GetComponent<TimingManager>();
        player = GameObject.Find("Player");
        enemy = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>();
    }


    // Update is called once per frame
    void Update()
    {
        // deltaTime * noteSpeed ������ x ��ǥ �̵������� 
        transform.Translate(moveSpeed * Time.deltaTime * key, 0, 0);

    }

    
    void Dead()
    {
        moveSpeed = 0.0f;
        Debug.Log("��");
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
                // �÷��̾ ���� ���� �ְ�, ���� �÷��̾��� ���ʿ� ���� ���
                {
                    Dead();
                }
                else if (player.GetComponent<PlayerController>().key < 0 && hitCondition < 0)
                // �÷��̾ ������ ���� �ְ�, ���� �÷��̾��� �����ʿ� ���� ���
                {
                    Dead();
                }

            }          
        }

    }
}
