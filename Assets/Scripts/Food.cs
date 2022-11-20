using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag+"INter");
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerState>().AddBody();
            Destroy(gameObject);
        }
    }

    public static Food Create(Vector3 pos, GameObject parent)
    {
        GameObject gameObject = Instantiate(GameManager.instance.food, parent.transform);
        gameObject.transform.position = pos;
        return gameObject.GetComponent<Food>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
