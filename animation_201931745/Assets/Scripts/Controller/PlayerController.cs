using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int key = 0;

    TimingManager timingManager;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        this.timingManager = GameObject.Find("NoteGenerator").GetComponent<TimingManager>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            key = 5;
            // 판정 체크
            this.timingManager.CheckTiming();
            if (this.timingManager.hit) this.animator.SetTrigger("AttackTrigger");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            key = -5;
            // 판정 체크
            this.timingManager.CheckTiming();
            if (this.timingManager.hit) this.animator.SetTrigger("AttackTrigger");
        }

        if (key != 0)
        {
            transform.localScale = new Vector3(key, 5, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("플레이어");
/*
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }*/
    }
}
