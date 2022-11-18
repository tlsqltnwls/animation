using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public float noteSpeed = 0.0f;

  
    // Update is called once per frame
    void Update()
    {
        // deltaTime * noteSpeed ������ x ��ǥ �̵������� 
        transform.Translate(noteSpeed * Time.deltaTime, 0, 0);
        
    }

    public void HideNote()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        // ȭ�鿡�� �Ⱥ��̰� ��Ȱ��ȭ ������
    }

}
