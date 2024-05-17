using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;            //���� ������ ������Ʈ
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
                int RandNumber = Random.Range(0, 3);                    //0 ~ 2���� �� ���� ���ڸ� ����
                GameObject Temp = Instantiate(CircleObject[0]);        //���� ������ ������Ʈ�� ���� �����ش�. (Instantiate)
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
    
    public void MergeObject(int index, Vector3 position)      //Merge �Լ��� ���Ϲ�ȣ(int) �� ���� ��ġ��(Vector3)�� ���� �޴´�.
    {
        GameObject Temp = Instantiate(CircleObject[index]); //index�� �״�� ����. (0 ���� �迭�� ���۵����� index ���� 1 ���־)
        Temp.transform.position = position;                 //��ġ�� ���� ���� ������ ���
        Temp.GetComponent<CircleObject>().Used();           // ������ Used �Լ� ���

    }
}
