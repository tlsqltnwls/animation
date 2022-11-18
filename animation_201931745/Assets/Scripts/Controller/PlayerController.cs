using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    TimingManager timingManager;

    // Start is called before the first frame update
    void Start()
    {
        timingManager = GameObject.Find("NoteGenerator").GetComponent<TimingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 판정 체크
            timingManager.CheckTiming();
        }
    }
}
