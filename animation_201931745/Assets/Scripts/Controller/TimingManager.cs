using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();
                                                    // ������ ��Ʈ�� ��� List
                                                    // ���� ������ �ִ��� ��� ��Ʈ�� ���ؾ���

    [SerializeField] Transform Center = null;       // ���� ������ �߽��� �˷���
    [SerializeField] Transform[] timingRect = null; // ���� ���� (Perfect, Cool, Good, Bad)
    Vector2[] timingBoxs = null;                    // ���� ������ �� �迭 (���� ������ �ּҰ�(x), �ִ밪(y))

    GameObject director;

    public bool hit = false; // ��Ʈ�� �������� �ȿ� �ִ��� Ȯ��


    // Start is called before the first frame update
    void Start()
    {
        director = GameObject.Find("GameDirector");
        // Ÿ�̹� �ڽ� ����
        timingBoxs = new Vector2[timingRect.Length]; // timingRect �迭�� ũ��� ���� ���� ������

        for (int i = 0; i < timingBoxs.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].localScale.x / 2,
                              Center.localPosition.x + timingRect[i].localScale.x / 2);

            /* ���� ������ ���� �߽��� Center�� �������� ������Ʈ �ʺ��� ���� �� ���� x��
                �ʺ��� ���� �����ذ� y�� ������ ��������
                �� ������ ���� ����
                => �ּҰ� = �߽� - (������Ʈ�� �ʺ� / 2)
                   �ִ밪 = �߽� + (������Ʈ�� �ʺ� / 2)
                �̷��� x���� y ������ ���� ���� ������ ��
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
                        // ������ ��Ʈ�� ������ŭ �ݺ���
        {
            float notePosX = boxNoteList[i].transform.localPosition.x;
                        // ��Ʈ�� x���� �޾Ƽ� �� ������ �������� �ȿ� ���Դ��� �Ǵ�

            for (int j = 0; j < timingBoxs.Length; j++)
                        // ��Ʈ���� �������� �ȿ� �ִ��� Ȯ���ؾ� ��
            {
                

                Debug.Log("notePosX: " + notePosX);
                if (timingBoxs[j].x <= notePosX && notePosX <= timingBoxs[j].y)
                {
                    hit = true;

                    //director.GetComponent<GameDirector>().Hit();

                    // ���� ������ ������ �ʿ䰡 ���ٸ� ��Ȱ��ȭ
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
