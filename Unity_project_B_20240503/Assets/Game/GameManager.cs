using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] CircleObject;            //���� ������ ������Ʈ
    public Transform GenTransform;              //������ ������ ��ġ ������Ʈ
    public float TiemCheck;                     //�ð��� üũ�ϱ� ���� (float) ��
    public bool isGen;                          // ���� �Ϸ� üũ (bool) ��

    public int Point;                           // ���� �� ����(int)
    public int BestScore;
    public static event Action<int> OnPointChanged;         //event Action ���� (Point ���� ����� ��� ȣ��)
    public static event Action<int> OnBestScorehanged;         //event Action ���� (Point ���� ����� ��� ȣ��)
                                          

    void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore");
        GenObject();                        //������ ���۵Ǿ����� �Լ��� ȣ���ؼ� �ʱ�ȭ ��Ų��.
        OnPointChanged?.Invoke(Point);
        OnBestScorehanged?.Invoke(BestScore);
    }

   
    void Update()
    {
        if (!isGen)
        {
            TiemCheck -= Time.deltaTime;        //�� �����Ӹ��� ������ �ð��� ���ش�.
            if(TiemCheck <=0)
            {
                int RandNumber = UnityEngine.Random.Range(0, 3);                    //0 ~ 2���� �� ���� ���ڸ� ����
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

        Point += (int)Mathf.Pow(index, 2) * 10;              // Index�� 2������ ���� ����Ʈ ���� Pow �Լ� ���
        OnPointChanged?. Invoke(Point);                     // ����Ʈ�� ����Ǿ����� �̺�Ʈ�� ���� �Ǿ��ٰ� �˸�
    }

    public void EndGame()
    {
        if(Point > BestScore)                                       // ����Ʈ�� ���Ѵ�.
        {
            BestScore = Point;
            PlayerPrefs.GetInt("BestScore" , Point);              // ����Ʈ�� �� Ŭ��� �����Ѵ�.
            OnPointChanged?.Invoke(BestScore);
        }
    }
}
