using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
                                                    // 생성된 노트를 담는 List
                                                    // 판정 범위에 있는지 모든 노트를 비교해야함

    [SerializeField] Transform Center = null;       // 판정 범위의 중심을 알려줌
    [SerializeField] Transform[] timingRect = null; // 판정 범위 (Perfect, Cool, Good, Bad)
    Vector2[] timingBoxs = null;                    // 실제 판정에 쓸 배열 (판정 범위의 최소값(x), 최대값(y))

    GameObject director;

    public bool hit = false; // 노트가 판정범위 안에 있는지 확인


    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");
        // 타이밍 박스 설정
        timingBoxs = new Vector2[timingRect.Length]; // timingRect 배열의 크기로 판정 범위 맞춰줌

        for (int i = 0; i < timingBoxs.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].localScale.x / 2,
                              Center.localPosition.x + timingRect[i].localScale.x / 2);

            /* 판정 범위는 판정 중심인 Center를 기준으로 오브젝트 너비의 반을 뺀 값을 x로
                너비의 반을 더해준걸 y의 값으로 지정해줌
                즉 각각의 판정 범위
                => 최소값 = 중심 - (오브젝트의 너비 / 2)
                   최대값 = 중심 + (오브젝트의 너비 / 2)
                이러면 x에서 y 사이의 값이 판정 범위가 됨
             */
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void CheckTiming()
    {

       

        for (int i = 0; i < boxNoteList.Count; i++)
                        // 생성된 노트의 개수만큼 반복문
        {
            float notePosX = boxNoteList[i].transform.localPosition.x;
                        // 노트의 x값을 받아서 이 값으로 판정범위 안에 들어왔는지 판단

            for (int j = 0; j < timingBoxs.Length; j++)
                        // 노트마다 판정범위 안에 있는지 확인해야 됨
            {
                

                Debug.Log("notePosX: " + notePosX);
                if (timingBoxs[j].x <= notePosX && notePosX <= timingBoxs[j].y)
                {
                    hit = true;

                    //director.GetComponent<GameDirector>().Hit();

                    // 판정 범위를 보여줄 필요가 없다면 비활성화
                    boxNoteList[i].GetComponent<NoteController>().HideNote();
                    boxNoteList.RemoveAt(i);
                    Debug.Log("Hit" + j);
                    return;
                }
                else
                {
                    hit = false;

                    //director.GetComponent<GameDirector>().NoHit();
                    //Debug.Log("miss!!!!!!");
                }
                hit = false;
            }
        }

    }

}
