using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    //~�߿�~ Ÿ���� ��ġ�� ������ ��
    public GameObject[] Target;

    void Start()
    {
        foreach (GameObject a in Target)
        {
            a.SetActive(true);
            a.transform.localPosition = new Vector3(Random.Range(-12, 12), 0.5f, Random.Range(-9, 9));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
