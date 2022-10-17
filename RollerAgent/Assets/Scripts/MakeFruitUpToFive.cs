using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ũ��Ʈ�� player���� �ٴ°���

// Fruit �� �ټ������� instantiate ���ְ�
// �� �տ� �ٿ��ֱ�
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
    // fruit box �տ� ���� �ڽĿ�����Ʈ ����� + ���� �ϳ� �ֿ�
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
        // ���̾��Ű â�� fruit �� 5���̸�
        if (GameManager1.Instance.count >= 4)
        {

            // destroy fruitbox
            Destroy(FruitBox, 0.5f);
        }
    }
}
