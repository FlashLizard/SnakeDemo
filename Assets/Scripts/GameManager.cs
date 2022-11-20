using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    [SerializeField]
    public GameObject snakeBody;
    public GameObject food;
    public GameObject snakeBodies;
    public GameObject foods;
    public float removeBodyInterval;
    public float createFoodInterval;
    public float left;
    public float right;
    public float top;
    public float bottom;

    private float removeBodyTimer = 0;
    private float createFoodTimer = 0;

    private void Awake()
    {
        GameManager.instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private float RandomNum(float x, float y)
    {
        return x + Random.value * (y - x);
    }

    private void FixedUpdate()
    {
        removeBodyTimer += Time.fixedDeltaTime;
        createFoodTimer += Time.fixedDeltaTime;
        if(removeBodyTimer>removeBodyInterval)
        {
            PlayerState.instance.RemoveBody();
            removeBodyTimer = 0;
        }
        if (createFoodTimer > createFoodInterval)
        {
            Food.Create(new Vector3(RandomNum(left, right), RandomNum(top, bottom)),foods);
            createFoodTimer = 0;
        }
    }
}
