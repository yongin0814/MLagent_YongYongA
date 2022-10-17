using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �� ��ũ��Ʈ�� �������ִ� ������ �ٿ��ش� 

// ī��Ʈ�� �ö󰡸�
// ��� UI�� �ϳ��� ���ش� 

public class CountFruit : MonoBehaviour
{
    public int fruit = 0;
    public int maxFRUIT = 10;

    public GameObject[] fruitsUI;
    void Start()
    {
       
    }

    public int GetFruit()
    {
        return maxFRUIT;
    }

    // Update is called once per frame
    void Update()
    {
        SetFruit(GameManager1.Instance.count);
    }

    public void SetFruit(int value)
    {
        GameManager1.Instance.count = value;
        // 0~n-1������ Ű��
        for (int i = 0; i < value; i++)
        {
            fruitsUI[i].SetActive(true);
        }
        // n ~ ������ ����
        /*for (int i = value; i < fruitsUI.Length; i++)
        {
            fruitsUI[i].SetActive(false);
        }*/
        for (int i = value; i < fruitsUI.Length; i++)
        {
            fruitsUI[i].SetActive(false);
        }

        // value�� �ش��ϴ� �͸� Ų��
        //fruitsUI[value].SetActive(true);
    }
}
