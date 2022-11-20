using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public SnakeBody behindBody = null;
    public float interval = 0;

    public static SnakeBody Create(Vector3 pos,Vector3 dir, float interval, GameObject parent)
    {
        GameObject gameObject = Instantiate(GameManager.instance.snakeBody, parent.transform);
        SnakeBody tmp = gameObject.GetComponent<SnakeBody>();
        tmp.interval = interval;
        tmp.AdjectTransform(pos, dir);
        return tmp;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AdjectTransform(Vector3 pos)
    {
        Vector3 dir = (pos-transform.position).normalized;
        AdjectTransform(pos, dir);
    }

    void AdjectTransform(Vector3 pos, Vector3 dir)
    {
        dir = dir.normalized;
        Vector3 target = pos - dir*interval;
        transform.position = target;
        transform.up = dir;
        if (behindBody) behindBody.AdjectTransform(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
