using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 이 스크립트는 관리해주는 애한테 붙여준다 

// 카운트가 올라가면
// 용과 UI를 하나씩 켜준다 

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
        // 0~n-1개까지 키고
        for (int i = 0; i < value; i++)
        {
            fruitsUI[i].SetActive(true);
        }
        // n ~ 끝까지 끄기
        /*for (int i = value; i < fruitsUI.Length; i++)
        {
            fruitsUI[i].SetActive(false);
        }*/
        for (int i = value; i < fruitsUI.Length; i++)
        {
            fruitsUI[i].SetActive(false);
        }

        // value에 해당하는 것만 킨다
        //fruitsUI[value].SetActive(true);
    }
}
