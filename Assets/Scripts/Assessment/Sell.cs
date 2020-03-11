using UnityEngine;

public class Sell : MonoBehaviour
{
    private GameObject storage;
    private GameObject bank;
    public int mine;
    private int collect;
    private float gather = 0;
    private bool cFull;
    private bool mFull;
    // Start is called before the first frame update
    void Start()
    {
        mFull = false;
        cFull = false;
        mine = 0;
        storage = GameObject.Find("Storage");
        bank = GameObject.Find("Bank");
    }

    // Update is called once per frame
    void Update()
    {
        if (cFull)
        {
            if ((storage.transform.position - transform.position).sqrMagnitude > .5f)
            {
                Vector3 v = ((storage.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                v.y = 0;
                gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
            }
            else
            {
                if (collect != 0)
                {
                    if ((Time.time - gather) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                    {
                        collect--;
                        storage.GetComponent<Storage>().coin++;
                        if (collect == 0)
                        {
                            cFull = false;
                        }
                    }
                }
                else
                {
                    gameObject.GetComponent<Status>().money += 10;
                    gameObject.GetComponent<Movement>().velocity = new Vector3();
                    gameObject.GetComponent<TownsFolk>().current = gameObject.GetComponent<TownsFolk>().last;
                    gameObject.GetComponent<TownsFolk>().last = 0;
                    gameObject.GetComponent<Sell>().enabled = false;
                }
            }
        }
        else if (mFull)
        {
            if ((bank.transform.position - transform.position).sqrMagnitude > .5f)
            {
                Vector3 v = ((bank.transform.position - transform.position).normalized - gameObject.GetComponent<Movement>().velocity);
                v.y = 0;
                gameObject.GetComponent<Movement>().velocity += v * Time.deltaTime;
            }
            else
            {
                if ((Time.time - gather) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                {
                    collect += 2;
                    mine--;
                    if (mine == 0)
                    {
                        cFull = true;
                        mFull = false;
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
                if ((Time.time - gather) >= gameObject.GetComponent<TownsFolk>().gatherTime)
                { 
                    mine++;
                    if (mine == gameObject.GetComponent<TownsFolk>().capacity)
                    {
                        mFull = true;
                    }
                }
            }
        }
    }
}
