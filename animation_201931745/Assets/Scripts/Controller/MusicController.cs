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
        // 노트가 하나만 지나가는 것이 아니라 계속 지나가는 것이므로
        // 처음에만 한번 재생되게 bool 변수로 컨트롤 해줌
        // musicPlay = false 일 때만 노래 재생
        {
            if (collision.CompareTag("Note"))
            // 만약 충돌한 collision의 태그가 노트면 음악 플레이
            {
                //gameAudio.Play();

                musicPlay = true;
            }
        }
    }
}
