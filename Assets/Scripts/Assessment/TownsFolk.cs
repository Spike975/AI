using UnityEngine;

public class TownsFolk : MonoBehaviour
{
    private GameObject storage;
    private GameObject guardHouse;
    private GameObject townHouse;
    private GameObject home;

    public int capacity;
    public float gatherTime;

    public int current = 0;
    public int last = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        storage = GameObject.Find("Storage");
        guardHouse = GameObject.Find("GuardPost");
        townHouse = GameObject.Find("Town");
        home = GameObject.Find("Home");

        capacity = 20;
        gatherTime = .5f;

        gameObject.GetComponent<HireGuard>().enabled = false;
        gameObject.GetComponent<Mine>().enabled = false;
        gameObject.GetComponent<Farming>().enabled = false;
        gameObject.GetComponent<Rebuild>().enabled = false;
        gameObject.GetComponent<Trees>().enabled = false;
        gameObject.GetComponent<Sell>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if it is doing anything
        if (current == 0)
        {
            //Checks to see if there was a last function
            if (last == 0)
            {
                //This checks to see if townspeople should do anything


                int check = 0;
                //Checks to see if the Town is damaged, then checks to see how many other players have already are doing that task
                if (townHouse.GetComponent<Town>().health < 200)
                {
                    
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Rebuild>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 2)
                    {
                        current = 4;
                    }
                    else
                    {
                        check++;
                    }
                }
                //Checks to see if guards need to be hired, then checks to see how many other players have already are doing that task
                if (guardHouse.GetComponent<GuardPost>().guardDeath > 0 && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<HireGuard>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < guardHouse.GetComponent<GuardPost>().guardDeath)
                    {
                        current = 1;
                    }
                    else
                    {
                        check++;
                    }
                }
                //Checks to see if the storage limit for the mine has been reached, then checks to see how many other players have already are doing that task
                if (storage.GetComponent<Storage>().mine < storage.GetComponent<Storage>().mineCap && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Mine>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 5)
                    {
                        current = 2;
                    }
                    else
                    {
                        check++;
                    }

                }
                //Checks to see if the storage limit for food has been reached, then checks to see how many other players have already are doing that task
                if (storage.GetComponent<Storage>().food < storage.GetComponent<Storage>().foodCap && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Farming>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 4)
                    {
                        current = 3;
                    }
                    else
                    {
                        check++;
                    }
                }
                //Checks to see if the player can get a full capacity, then checks to see if there are too many players doing this task
                if (storage.GetComponent<Storage>().mine  >= capacity && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Sell>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 3)
                    {
                        current = 6;
                    }
                }
                //Checks to see if the storage limit for building materials has been reached, then checks to see how many other players have already are doing that task
                if (storage.GetComponent<Storage>().building >= storage.GetComponent<Storage>().buildCap && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Trees>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 2)
                    {
                        current = 5;
                    }
                    else
                    {
                        check++;
                    }
                }
                //if it went trough everything and didn't assign anything, it moves to the 'Home' object and waits
                if (check == 5)
                {
                    if ((home.transform.position - transform.position).sqrMagnitude >= .25f)
                    {
                        Vector3 v = (home.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity;
                        v.y = 0;
                        gameObject.GetComponent<Movement>().velocity += v * Time.time;
                    }
                    else
                    {
                        gameObject.GetComponent<Movement>().velocity = new Vector3();
                    }
                }
            }
            //Since the player needs to make money, they prioritize the highest paying job first
            else if (last == 1)
            {
                //Checks to see if the storage limit for building materials has been reached, then checks to see how many other players have already are doing that task
                if (storage.GetComponent<Storage>().mine >= capacity && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Sell>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 3)
                    {
                        current = 6;
                    }
                }
                //Checks to see if the storage limit for building materials has been reached, then checks to see how many other players have already are doing that task
                if (storage.GetComponent<Storage>().building >= storage.GetComponent<Storage>().buildCap && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Trees>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 2)
                    {
                        current = 5;
                    }
                }
                //Checks to see if the storage limit for the mine has been reached, then checks to see how many other players have already are doing that task
                if (storage.GetComponent<Storage>().mine < storage.GetComponent<Storage>().mineCap && current == 0)
                {
                    GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                    int confirm = 0;
                    for (int i = 0; i < g.Length; i++)
                    {
                        if (g[i].GetComponent<Mine>().isActiveAndEnabled)
                        {
                            confirm++;
                        }
                    }
                    if (confirm < 5)
                    {
                        current = 2;
                    }
                }
            }
            //Checks to see if there are too many players doing this task
            else if (last == 4)
            {
                GameObject[] g = GameObject.FindGameObjectsWithTag("Player");
                int confirm = 0;
                for(int i = 0; i < g.Length; i++)
                {
                    if (g[i].GetComponent<Trees>().isActiveAndEnabled)
                    {
                        confirm++;
                    }
                }
                if ((confirm * capacity * 2) < (townHouse.GetComponent<Town>().maxHealth - townHouse.GetComponent<Town>().health))
                {
                    current = 5;
                }
                else
                {
                    last = 0;
                }
            }
        }
        //Handles which script to enable
        else
        {
            if (current == 1)
            {
                gameObject.GetComponent<HireGuard>().enabled = true;
            }
            else if(current == 2)
            {
                gameObject.GetComponent<Mine>().enabled = true;
            }
            else if(current == 3)
            {
                gameObject.GetComponent<Farming>().enabled = true;
            }
            else if(current == 4)
            {
                gameObject.GetComponent<Rebuild>().enabled = true;
            }
            else if (current == 5)
            {
                gameObject.GetComponent<Trees>().enabled = true;
            }
            else if (current == 6)
            {
                gameObject.GetComponent<Sell>().enabled = true;
            }
        }
    }
}
