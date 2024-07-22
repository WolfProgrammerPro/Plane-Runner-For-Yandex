using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrassObjectController : MonoBehaviour
{
    [Tooltip("������� ������ HP")] public int minusingHP;
   [Tooltip("�������� �����������")] public float meinSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3((meinSpeed * DataBox.Instance.speed)/-1, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("�������");
        if (collision.gameObject.CompareTag("DestroyZone"))
        {
            //print("���");
            Destroy(gameObject);
        }
    }
}
