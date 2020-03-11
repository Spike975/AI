using UnityEngine;

public class Status : MonoBehaviour
{
    public int health;
    public int hunger;
    public int money;
    public float hungerDrain;
    private float drain;
    private float healthDrain = 0;
    private float hDrain = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0){
            if (gameObject.tag == "Guard")
            {
                GameObject.Find("GuardPost").GetComponent<GuardPost>().guardDeath++;
            }
            Destroy(gameObject);
        }
        if (hunger <= 0)
        {
            if ((Time.time - healthDrain) > hDrain)
            {
                healthDrain = Time.time;
                health--;
            }
        }
        if (hunger <= 20)
        {
            if (money > 0)
            {
                //Go buy food
            }
            else
            {
                //Make Money
            }
        }
        if (health <= 20)
        {
            //Go rest
        }
        if ((Time.time - drain) >= hungerDrain && hungerDrain != 0)
        {
            drain = Time.time;
            hunger--;
        }
    }
}