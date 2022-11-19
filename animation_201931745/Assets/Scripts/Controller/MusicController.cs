using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource gameAudio;
    bool musicPlay = false;

    // Start is called before the first frame update
    void Start()
    {
        gameAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicPlay)
        // ��Ʈ�� �ϳ��� �������� ���� �ƴ϶� ��� �������� ���̹Ƿ�
        // ó������ �ѹ� ����ǰ� bool ������ ��Ʈ�� ����
        // musicPlay = false �� ���� �뷡 ���
        {
            if (collision.CompareTag("Note"))
            // ���� �浹�� collision�� �±װ� ��Ʈ�� ���� �÷���
            {
                //gameAudio.Play();

                musicPlay = true;
            }
        }
    }
}
