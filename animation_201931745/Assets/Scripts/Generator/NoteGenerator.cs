using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public GameObject NotePrefab;
    public int bpm = 0;         // 1분 당 비트 수
    double currentTime = 0d;    // 노트 생성을 위한 시간을 체크해주는 변수
                                // float 보다 오차가 적은 double로 생성

    TimingManager timingManager;

    private void Start()
    {
        timingManager = GetComponent<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime; // currentTime을 1초에 1씩 증가하게 만듦

        noteAppear();
    }

    void noteAppear ()
    {
        if (currentTime >= 60d / this.bpm)
        // 비트 한 개 당 등장 속도 (60/120 = 1beat 당 0.5초)
        {
            GameObject notePrefab = Instantiate(NotePrefab);

            //t_note.transform.SetParent(this.transform);
            timingManager.boxNoteList.Add(notePrefab);
            // 노트가 생성되는 순간 노트 list에 해당 노트를 추가 시켜줌

            this.currentTime -= 60d / this.bpm; // currentTime = 0으로 하면 미세한 차이로 노트 생성이 계속 밀려버림
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            timingManager.boxNoteList.Remove(collision.gameObject);
                                // 원래는 Remove(collision.gameObject)로 하려 했지만 리스트가 삭제되지 않음
            Destroy(collision.gameObject);
        }
    }
}
