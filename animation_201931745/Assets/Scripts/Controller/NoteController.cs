using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float noteSpeed = 0.0f;

  
    // Update is called once per frame
    void Update()
    {
        // deltaTime * noteSpeed 값으로 x 좌표 이동시켜줌 
        transform.Translate(noteSpeed * Time.deltaTime, 0, 0);
        
    }

    public void HideNote()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        // 화면에서 안보이게 비활성화 시켜줌
    }

}
