using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static PlayerState instance = null;


    [SerializeField]
    public int originBodyNum = 3;
    public float bodyInterval = 0.5f;
    

    private SnakeBody head = null;
    private Stack<SnakeBody> snakeBodies;

    private void Awake()
    {
        instance = this;
    }

    public void AddBody()
    {
        Transform lastBody = snakeBodies.Peek().transform;
        SnakeBody tmp = SnakeBody.Create(lastBody.position, lastBody.up, bodyInterval, GameManager.instance.snakeBodies);
        snakeBodies.Peek().behindBody = tmp;
        snakeBodies.Push(tmp);
    }

    public void RemoveBody()
    {
        SnakeBody tmp = snakeBodies.Pop();
        Destroy(tmp.gameObject);
        if(snakeBodies.Count == 0)//Dead
        {

        }
        snakeBodies.Peek().behindBody = null;
    }

    public void AdjectBody(Vector3 pos)
    {
        if(snakeBodies.Count > 0)
        {
            head.AdjectTransform(pos);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        snakeBodies = new Stack<SnakeBody>();
        Vector3 pos = transform.position;
        SnakeBody tmp = head = SnakeBody.Create(pos, transform.up, bodyInterval, GameManager.instance.snakeBodies);
        snakeBodies.Push(tmp);
        pos = tmp.transform.position; ;
        for (int i = 1; i < originBodyNum; i++)
        {
            tmp = SnakeBody.Create(pos, transform.up, bodyInterval, GameManager.instance.snakeBodies);
            snakeBodies.Peek().behindBody = tmp;
            snakeBodies.Push(tmp);
            pos = tmp.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if(Input.GetKeyDown(KeyCode.U)) { AddBody(); }
        if(Input.GetKeyDown(KeyCode.I)) { RemoveBody(); }
    }
}
