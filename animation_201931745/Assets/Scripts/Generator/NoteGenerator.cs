using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public GameObject NotePrefab;
    public int bpm = 0;         // 1�� �� ��Ʈ ��
    double currentTime = 0d;    // ��Ʈ ������ ���� �ð��� üũ���ִ� ����
                                // float ���� ������ ���� double�� ����

    TimingManager timingManager;

    private void Start()
    {
        timingManager = GetComponent<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime; // currentTime�� 1�ʿ� 1�� �����ϰ� ����

        if (currentTime >= 60d / bpm)
                                // ��Ʈ �� �� �� ���� �ӵ� (60/120 = 1beat �� 0.5��)
        {
            GameObject t_note =  Instantiate(NotePrefab);

            //t_note.transform.SetParent(this.transform);
            timingManager.boxNoteList.Add(t_note);
                                // ��Ʈ�� �����Ǵ� ���� ��Ʈ list�� �ش� ��Ʈ�� �߰� ������

            currentTime -= 60d / bpm; // currentTime = 0���� �ϸ� �̼��� ���̷� ��Ʈ ������ ��� �з�����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            timingManager.boxNoteList.Remove(collision.gameObject);
                                // ������ Remove(collision.gameObject)�� �Ϸ� ������ ����Ʈ�� �������� ����
            Destroy(collision.gameObject);
        }
    }
}
