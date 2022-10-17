using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 player한테 붙는것임

// Fruit 를 다섯개까지 instantiate 해주고
// 내 앞에 붙여주기
public class MakeFruitUpToFive : MonoBehaviour
{
    private GameObject temp;
    private int howManyFruit;

    public GameObject Fruit;
    public GameObject FruitBox;
    public Vector3 playerPositionNow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HideFruitHere();
        DestroyFruitBox();
        
    }

    public Transform Pos;
    // fruit box 앞에 가면 자식오브젝트 생기고 + 과일 하나 주움
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Box") == true)
        {
            if (this.transform.childCount == 1)
            {
                GameObject temp = Instantiate(Fruit, Pos.position, Quaternion.identity);
                temp.transform.SetParent(transform);
                DestroyFruitBox();
            }
        }
    }

    private void DestroyFruitBox()
    {
        // 하이어라키 창에 fruit 가 5개이면
        if (GameManager1.Instance.count >= 4)
        {

            // destroy fruitbox
            Destroy(FruitBox, 0.5f);
        }
    }
}
