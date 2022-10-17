using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TimeAttack : MonoBehaviour
{
    public static TimeAttack Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public float time;
    public float limitTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Atack()
    {
        // �ð� �帣�� �ϱ� 
        time += Time.deltaTime;

        // �ð��� ���ѽð� ������ 
        if (GameManager1.Instance.count == 0 && time >= limitTime + 1)
        {
            GameManager1.Instance.loseUI.SetActive(true);
            // ���ӿ��� 
            //SceneManager.LoadScene
        }

        // �ð��� ���ѽð� ������ 
        if (GameManager1.Instance.count > 0 && time >= limitTime + 1)
        {
                GameManager1.Instance.winUI.SetActive(true);
            // ���ӿ��� 
            //SceneManager.LoadScene
        }
    }
}
