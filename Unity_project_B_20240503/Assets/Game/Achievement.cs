using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Achievement        // ���� Ŭ���� ���� (MonoBehaviour X)
{
    public string name;              // ���� �̸�
    public string description;      //  ���� ����
    public bool isUnlocked;         //  ��� ����
    public int currentProgress;     //  ���� ����
    public int goal;                //  �Ϸ� ����


    public Achievement(string name, string description, int goal)       //������ �Լ�
    {
        this.name = name;                       // ���� �� �� �̸� �μ��� �޾Ƽ� ����
        this.description = description;       
        this.isUnlocked = false;
        this.currentProgress = 0;
        this.goal = goal;
    }

   public void AddProgress(int amount)       // ���� ���൵ �Լ�
    {
        if (!isUnlocked)                    //������� �ʴٸ�
        {
            currentProgress += amount;
            if(currentProgress >= goal)         // ���൵���� �Ϸ� ���ڰ� �� ���� ��
            {
                isUnlocked = true;
                OnAchievementUnlocked();        // ���� �޼��� Debug.Log ���
            }
        }
    }

    protected virtual void OnAchievementUnlocked()
    {
        Debug.Log($"���� �޼� : {name}");               //$ ǥ�ð� ����ִ� String ���� {} ���� ���� ��� �� �� �ִ�.
    }
}

