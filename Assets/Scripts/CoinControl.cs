using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            Debug.Log("1111111111");
            //¼Ó·Ö
            SendCustomMessage(MessageType.Type_UI, MessageType.UI_AddScore, 1);

            //Ïú»Ù
            Destroy(gameObject);
        }
    }
}
