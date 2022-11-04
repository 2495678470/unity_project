using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBase
{
    public Text scoreText;
    private int score = 0;

    public override void ReceiveMessage(Message message)
    {
        base.ReceiveMessage(message);
        if (message.Command == MessageType.UI_AddScore)
        {
            score += (int)message.Content;
            scoreText.text = score + "";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.RegisterReceiver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
