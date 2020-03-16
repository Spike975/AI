using UnityEngine;

public class Rebuild : MonoBehaviour
{
    private GameObject town;
    private GameObject storage;
    public int materials;
    private float lastTime;
    private bool filled = false;
    // Start is called before the first frame update
    void Start()
    {
        town = GameObject.Find("Town");
        storage = GameObject.Find("Storage");
        materials = 0;
        lastTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if the town is hurt
        if (town.GetComponent<Town>().health < town.GetComponent<Town>().maxHealth)
        {
            //checks to see if there are materials
            if (storage.GetComponent<Storage>().building > 0)
            {
                if (filled)
                {
                    if ((town.transform.position - transform.position).sqrMagnitude > .5f)
                    {
                        Vector3 v = ((town.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                        v.y = 0;
                        gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
                    }
                    else
                    {
                        gameObject.GetComponent<Movement>().velocity = new Vector3();
                        if ((Time.time - lastTime) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                        {
                            lastTime = Time.time;
                            materials--;
                            town.GetComponent<Town>().health += 2;
                            if (materials == 0)
                            {
                                filled = false;
                                gameObject.GetComponent<Movement>().velocity = new Vector3();
                                gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
                                gameObject.GetComponent<TownsFolk>().last = 0;
                                gameObject.GetComponent<Rebuild>().enabled = false;
                            }
                        }
                    }
                }
                else
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
                        if ((Time.time - lastTime) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                        {
                            lastTime = Time.time;
                            storage.GetComponent<Storage>().building--;
                            materials++;
                            if (materials == (town.GetComponent<Town>().maxHealth- town.GetComponent<Town>().health)/2 || materials == gameObject.GetComponent<TownsFolk>().capacity)
                            {
                                filled = true;
                            }
                        }
                    }
                }
            }
            //Goes and gathers materials
            else
            {
                gameObject.GetComponent<Movement>().velocity = new Vector3();
                gameObject.GetComponent<TownsFolk>().current = 0;
                gameObject.GetComponent<TownsFolk>().last = 4;
                gameObject.GetComponent<Rebuild>().enabled = false;
            }
        }
        else
        {
            gameObject.GetComponent<Movement>().velocity = new Vector3();
            gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
            gameObject.GetComponent<TownsFolk>().last = 0;
            gameObject.GetComponent<Rebuild>().enabled = false;
        }
    }
}