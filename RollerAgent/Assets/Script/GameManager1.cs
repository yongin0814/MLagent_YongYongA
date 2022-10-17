using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int count;
    bool isBunny = false;
    public GameObject Dragon;
    //public GameObject DragonPoint;

    public GameObject winUI;
    public GameObject loseUI;

    private bool dragonYes = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        winUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 4 && isBunny == false)
        {
            isBunny = true;
            StartCoroutine("Bunny");
        }
        print(count);

/*        // ���� �ڽ� ������
        if ((GameObject.Find("FruitBox") == false) && dragonYes == false)
        {
            // �� ����
            Instantiate(Dragon, DragonPoint.transform);

            //// �巡�� ����Ʈ��.
            //Dragon.transform.position = DragonPoint.transform.forward;

            // dragonYes == true�� �ٲ��ֱ�!
            dragonYes = true;


        }*/
    }

    IEnumerator Bunny()
    {
        yield return new WaitForSeconds(2f);
        Dragon.SetActive(true);
        TimeAttack.Instance.Atack();
        if (count == 0)
        {
            winUI.SetActive(true);
        }
    }
}
