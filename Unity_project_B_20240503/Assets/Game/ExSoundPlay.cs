using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExSoundPlay : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))             // 1번을 누르면
        {
            SoundManger.instance.PlaySound("BackGround");     // BackGround 재생
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))           // 2번을 누르면
        {
            SoundManger.instance.PlaySound("Cannon");       // Cannon 재생
        }
    }
}
