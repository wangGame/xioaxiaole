using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int x;
    private int y;
    private GameManager.SweetsType type;

    public GameManager.SweetsType Type {
        get {
            return type;
        }
        set {
            type = value;
        }

    }

    public GameManager gameManager;

    public int X {
        get {
            return x;
        }
        set {
            x = value;
        }
    }

    public int Y
    {
        get
        {
            return y;
        }
        set
        {
            y = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int x,int y,GameManager gameManager,GameManager.SweetsType type) {
        this.x = x;
        this.y = y;
        this.gameManager = gameManager;
        this.type = type; 
    }
}
