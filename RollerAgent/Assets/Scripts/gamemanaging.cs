using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �� ��ũ��Ʈ�� �Ŵ����� �ٴ°Ŵ� 

// box destroy �Ǹ� 3�� �ڿ� �� ��������
public class gamemanaging : MonoBehaviour
{
    public GameObject Dragon;
    public GameObject DragonPoint;

    //private bool dragonYes = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //DragonInstant();
    }

/*    private void DragonInstant()
    {

        // ���� �ڽ� ������
        if ((GameObject.Find("FruitBox") == false) && dragonYes == false)
        {
            // �� ����
            Instantiate(Dragon,DragonPoint.transform);

            //// �巡�� ����Ʈ��.
            //Dragon.transform.position = DragonPoint.transform.forward;

            // dragonYes == true�� �ٲ��ֱ�!
            dragonYes = true;


        }
    }*/
}
