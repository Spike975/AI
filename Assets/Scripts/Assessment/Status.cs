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

    // Update is called once per frame
    void Update()
    {
        //If health is < 0, destory object
        if (health <= 0){
            //If the object was a guard, increase the amount of guards needed to spawn back in
            if (gameObject.tag == "Guard")
            {
                GameObject.Find("GuardPost").GetComponent<GuardPost>().guardDeath++;
            }
            Destroy(gameObject);
        }
        //if hunger <= 0, slowly drain the health of the object
        if (hunger <= 0)
        {
            if ((Time.time - healthDrain) > hDrain)
            {
                healthDrain = Time.time;
                health--;
            }
        }
        //Not implemented yet
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
        //Not implemented yet
        if (health <= 20)
        {
            //Go rest
        }
        //Slowly drains the objects hunger
        if ((Time.time - drain) >= hungerDrain && hungerDrain != 0)
        {
            drain = Time.time;
            hunger--;
        }
    }
}