using UnityEngine;

public class Status : MonoBehaviour
{
    public float health;
    public float hunger;
    public float money;
    public float hungerDrain;
    private float drain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 || hunger <= 0){
            Destroy(gameObject);
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