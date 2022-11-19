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
        this.currentTime += Time.deltaTime; // currentTime�� 1�ʿ� 1�� �����ϰ� ����

        noteAppear();
    }

    void noteAppear ()
    {
        if (currentTime >= 60d / this.bpm)
        // ��Ʈ �� �� �� ���� �ӵ� (60/120 = 1beat �� 0.5��)
        {
            GameObject notePrefab = Instantiate(NotePrefab);

            //t_note.transform.SetParent(this.transform);
            timingManager.boxNoteList.Add(notePrefab);
            // ��Ʈ�� �����Ǵ� ���� ��Ʈ list�� �ش� ��Ʈ�� �߰� ������

            this.currentTime -= 60d / this.bpm; // currentTime = 0���� �ϸ� �̼��� ���̷� ��Ʈ ������ ��� �з�����
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
