using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CircleObject;            //���� ������ ������Ʈ
    public Transform GenTransform;              //������ ������ ��ġ ������Ʈ
    public float TiemCheck;                     //�ð��� üũ�ϱ� ���� (float) ��
    public bool isGen;                          // ���� �Ϸ� üũ (bool) ��
    
    void Start()
    {
        GenObject();                        //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��.
    }

   
    void Update()
    {
        if (!isGen)
        {
            TiemCheck -= Time.deltaTime;        //�� �����Ӹ��� ������ �ð��� ���ش�.
            if(TiemCheck <=0)
            {
                GameObject Temp = Instantiate(CircleObject);        //���� ������ ������Ʈ�� ���� �����ش�. (Instantiate)
                Temp.transform.position = GenTransform.position;        //������ ��ġ�� �̵� ��Ų��.
                isGen = true;                                       //Gen�� �Ǿ��ٰ� true�� bool ���� �����Ѵ�.
            }
        } 
    }

    public void GenObject()
    {
        isGen = false;           //�ʱ�ȭ isGen�� false(���� ���� �ʾҴ�.)
        TiemCheck = 1.0f;       // 1���� ���� �������� ���� ��Ű�� ���� �ʱ�ȭ
        
    }
}
