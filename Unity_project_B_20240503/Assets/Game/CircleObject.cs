using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleObject : MonoBehaviour
{
    public bool isDrag;             // �巡�� ������ �Ǵ��ϴ� (bool)
    public bool isUsed;             // ��� �Ϸ� �Ǵ��ϴ� (bool)
    Rigidbody2D rigidbody2D;      // ������ 2D�� �ҷ��´�

    public int index;               //���� ��ȣ�� �����.

    public float EndTime = 0.0f;                //���� �� �ð� üũ ����(float)
    public SpriteRenderer spriteRenderer;       

    public GameManager gameManager;             // GamEManger ���� ����
   
     void Awake()                                       // �����ϱ��� �ҽ�  �ܰ迡�� �ʱ�ȭ
    {
        isUsed = false;                                 // ��� �Ϸᰡ ���� ����(ó�����)
        rigidbody2D = GetComponent<Rigidbody2D>();        // ������ �����´�.
        rigidbody2D.simulated = false;                  // �����ɶ��� �ùķ����� ���� �ʴ´�.
        spriteRenderer = GetComponent<SpriteRenderer>();        // �ش� ������Ʈ�� ��������Ʈ ������ ����
    }

  

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();     //���� �޴����� ���´�.
     
    }


    void Update()
    {
        if (isUsed) return;                 //���Ϸ�� ��ü�� ���� ������Ʈ ���� �ʱ� ���ؼ� return �� ���� �ش�.

        if (isDrag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);         // ȭ�鿡�� -> ���� ������ ��ġ ã���ִ� �Լ� ���
            float leftBorder = -4f + transform.localScale.x / 2f;                         // �ִ� �������� �� �� �ִ� ����
            float rightBorder = 4f - transform.localScale.x / 2f;                         // �ִ� ���������� �� �� �ִ� ����

            if (mousePos.x < leftBorder) mousePos.x = leftBorder;                       
            if(mousePos.x > rightBorder) mousePos.x = rightBorder;

            mousePos.y = 8;
            mousePos.z = 0;

            transform.position = Vector3.Lerp(transform.position, mousePos, 0.2f);  // �� ������Ʈ�� ��ġ�� ���콺 ��ġ�� �̵� �ȴ�. 0.2f �ӵ��� �̵��ȴ�.
        }

        if (Input.GetMouseButtonDown(0)) Drag();        //���콺 ��ư�� ������ �� Drag �Լ� ȣ��
        if (Input.GetMouseButtonUp(0)) Drop();          //���콺 ��ư�� �ö� �� Drop �Լ� ȣ��
    }
    
    void Drag() 
    {
        isDrag = true;                  //�巡�� ���� (true)
        rigidbody2D.simulated = false;  //�巡�� �߿��� ���� ������ �Ͼ�°��� ���� ���ؼ�(flase)
    }

   void Drop()
    {
        isDrag = false;              //�巡�װ� ����
        isUsed = true;              //����� �Ϸ�
        rigidbody2D.simulated = true; //���� ���� ����

        GameObject Temp = GameObject.FindWithTag("GameManager");     //Tag : GameManger�� ã�Ƽ� ������Ʈ�� �����´�.
        if (Temp != null)                                           
        {
            Temp.gameObject.GetComponent<GameManager>().GenObject();
        }
    }

    public void Used()
    {
        isDrag = false;                             //�巡�װ� ����
        isUsed = true;                              //����� �Ϸ�
        rigidbody2D.simulated = true;               //���� ���� ����
    }

      public void OnTriggerStay2D(Collider2D collision)       //2D �浹�� ���� ��
    {
        if (collision.tag == "EndLine")
        {
            EndTime += Time.deltaTime;          // ������ ���۸�ŭ ���� ���Ѽ� �ʸ� �����.

            if(EndTime > 1)
            {
                spriteRenderer.color = new Color(0.9f, 0.2f, 0.2f);
            }
            if(EndTime > 3)
            {
                gameManager.EndGame();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "EndLine")          //�浹 ��ü�� ���� ��������
        {
            EndTime = 0.0f;
            spriteRenderer.color = Color.white;      // ���� �������� ����
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)      //2D �浹�� �Ͼ ���
    {
        if (index >= 7)                     //�غ�� ������ �ִ� 7��
            return;

        if(collision.gameObject.tag == "Fruit") 
        {
            CircleObject temp = collision.gameObject.GetComponent<CircleObject>(); // �ӽ÷� Class temp�� �����ϰ� �浹ü�� Class(CircleObject)�� �޾ƿ´�.

            if(temp.index == index)
            {
                if(gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())       //����Ƽ���� �����ϴ� ������ ID�� ū�ʿ��� ���� ���� ����
                {
                    //GameManger ���� �����Լ� ȣ��
                    GameObject Temp = GameObject.FindWithTag("GameManager");     //Tag : GameManger�� ã�Ƽ� ������Ʈ�� �����´�.
                    if (Temp != null)
                    {
                        Temp.gameObject.GetComponent<GameManager>().MergeObject(index, gameObject.transform.position);          //������ MerageObject �Լ��� �μ��� �Զ� ����
                    }
                    Destroy(temp.gameObject);                       //�浹 ��ü �ı�
                    Destroy(gameObject);                            // �ڱ� �ڽ� �ı�
                }
            }
        }
    }
}
