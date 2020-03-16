using UnityEngine;

public class Trees : MonoBehaviour
{
    private GameObject forest;
    private GameObject storage;
    public int wood;
    private float pickup;
    private bool filled;
    // Start is called before the first frame update
    void Start()
    {
        wood = 0;
        pickup = 0;
        filled = false;
        forest = GameObject.Find("Forest");
        storage = GameObject.Find("Storage");
    }

    // Update is called once per frame
    void Update()
    {
        if (storage.GetComponent<Storage>().building + gameObject.GetComponent<TownsFolk>().capacity <= storage.GetComponent<Storage>().buildCap)
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
                        wood--;
                        pickup = Time.time;
                        storage.GetComponent<Storage>().building++;
                        if (wood == 0)
                        {
                            gameObject.GetComponent<Status>().money += 5;
                            filled = false;
                            gameObject.GetComponent<Movement>().velocity = new Vector3();
                            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
                            gameObject.GetComponent<TownsFolk>().last = 0;
                            gameObject.GetComponent<Trees>().enabled = false;
                        }
                    }
                }
            }
            else
            {
                if ((forest.transform.position - transform.position).sqrMagnitude > .5f)
                {
                    Vector3 v = ((forest.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                    v.y = 0;
                    gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                }
                else
                {
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                    if (wood <= gameObject.GetComponent<TownsFolk>().capacity)
                    {
                        if ((Time.time - pickup) > gameObject.GetComponent<TownsFolk>().gatherTime)
                        {
                            pickup = Time.time;
                            wood++;
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
            gameObject.GetComponent<Trees>().enabled = false;
        }
    }
}
