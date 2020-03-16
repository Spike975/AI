using UnityEngine;

public class Farming : MonoBehaviour
{
    private GameObject farm;
    private GameObject storage;

    private bool filled;
    private int gathered;
    private float pickup;

    // Start is called before the first frame update
    void Start()
    {
        farm = GameObject.Find("Farm");
        storage = GameObject.Find("Storage");
        filled = false;
        pickup = 0;
        gathered = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (storage.GetComponent<Storage>().food + gameObject.GetComponent<TownsFolk>().capacity <= storage.GetComponent<Storage>().buildCap)
        {
            if (filled)
            {
                if ((storage.transform.position - transform.position).sqrMagnitude > .5f)
                {
                    Vector3 v = ((storage.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                    v.y = 0;
                    gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                }
                else
                {
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                    if ((Time.time - pickup) > gameObject.GetComponent<TownsFolk>().gatherTime)
                    {
                        pickup = Time.time;
                        gathered--;
                        storage.GetComponent<Storage>().food++;
                        if (gathered == 0)
                        {
                            gameObject.GetComponent<Status>().money += 4;
                            filled = false;
                            gameObject.GetComponent<Movement>().velocity = new Vector3();
                            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
                            gameObject.GetComponent<TownsFolk>().last = 0;
                            gameObject.GetComponent<Farming>().enabled = false;
                        }
                    }
                }
            }
            else
            {
                if ((farm.transform.position - transform.position).sqrMagnitude > .5f)
                {
                    Vector3 v = ((farm.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                    v.y = 0;
                    gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                }
                else
                {
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                    if (gathered <= gameObject.GetComponent<TownsFolk>().capacity)
                    {
                        if ((Time.time - pickup) > gameObject.GetComponent<TownsFolk>().gatherTime)
                        {
                            pickup = Time.time;
                            gathered++;
                        }
                    }
                    else
                    {
                        filled = true;
                    }
                }
            }
        }
        else
        {
            gameObject.GetComponent<Movement>().velocity = new Vector3();
            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
            gameObject.GetComponent<TownsFolk>().last = 0;
            gameObject.GetComponent<Farming>().enabled = false;
        }
    }
}