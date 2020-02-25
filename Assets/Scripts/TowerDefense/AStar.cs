using UnityEngine;

public class AStar : MonoBehaviour
{
    struct Node
    {
        public GameObject cur;
        public GameObject prev;
        public int g;
        public int h;
        public int f;
    }

    private Node[] open;
    private Node[] close;
    public GameObject[] path;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            int openLength = 0;
            int closeLength = 0;
            GameObject start = GameObject.Find("Start");
            int length = start.GetComponent<BlockBuilder>().x * start.GetComponent<BlockBuilder>().y;
            open = new Node[length];
            close = new Node[length];
            open[0].cur = GameObject.Find("Spawn");
            open[0].prev = null;
            open[0].f = 0;
            open[0].g = 0;
            open[0].h = 0;
            openLength++;

            for(int i = 0; i < close.Length; i++)
            {
                Node temp = open[0];
                close[closeLength] = open[0];
                closeLength++;
                open[0] = new Node();
                openLength--;
                if (temp.cur.name == "End")
                {
                    break;
                }
                for (int x = 0; x < openLength; x++)
                {
                    if (open[x].cur == null && open[x + 1].cur != null && x < open.Length - 1)
                    {
                        open[x] = open[x + 1];
                        open[x + 1] = new Node();
                    }
                }
                if(temp.cur.GetComponent<NodeScript>().around[0] != null)
                {
                    bool change = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[0])
                        {
                            if (close[x].f > temp.f)
                            {
                                close[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                close[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                close[x].f = open[x].h + open[x].g;
                                close[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[0])
                        {
                            if (open[x].f > temp.f)
                            {
                                open[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                open[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                open[x].f = open[x].h + open[x].g;
                                open[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    if (!change)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[0];
                        open[openLength].prev = temp.cur;
                        open[openLength].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                        open[openLength].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                        open[openLength].f = open[openLength].g + open[openLength].h;
                        openLength++;
                    }
                }
                if (temp.cur.GetComponent<NodeScript>().around[1] != null)
                {
                    bool change = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[1])
                        {
                            if (close[x].f > temp.f)
                            {
                                close[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                close[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                close[x].f = open[x].h + open[x].g;
                                close[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[1])
                        {
                            if (open[x].f > temp.f)
                            {
                                open[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                open[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                open[x].f = open[x].h + open[x].g;
                                open[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    if (!change)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[1];
                        open[openLength].prev = temp.cur;
                        open[openLength].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                        open[openLength].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                        open[openLength].f = open[openLength].g + open[openLength].h;
                        openLength++;
                    }
                }
                if (temp.cur.GetComponent<NodeScript>().around[2] != null)
                {
                    bool change = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[2])
                        {
                            if (close[x].f > temp.f)
                            {
                                close[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                close[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                close[x].f = open[x].h + open[x].g;
                                close[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[2])
                        {
                            if (open[x].f > temp.f)
                            {
                                open[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                open[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                open[x].f = open[x].h + open[x].g;
                                open[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    if (!change)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[2];
                        open[openLength].prev = temp.cur;
                        open[openLength].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                        open[openLength].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                        open[openLength].f = open[openLength].g + open[openLength].h;
                        openLength++;
                    }
                }
                if (temp.cur.GetComponent<NodeScript>().around[3] != null)
                {
                    bool change = false;
                    for (int x = 0; x < closeLength; x++)
                    {
                        if (close[x].cur == temp.cur.GetComponent<NodeScript>().around[3])
                        {
                            if (close[x].f > temp.f)
                            {
                                close[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                close[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                close[x].f = open[x].h + open[x].g;
                                close[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    for (int x = 0; x < openLength; x++)
                    {
                        if (open[x].cur == temp.cur.GetComponent<NodeScript>().around[3])
                        {
                            if (open[x].f > temp.f)
                            {
                                open[x].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                                open[x].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                                open[x].f = open[x].h + open[x].g;
                                open[x].prev = temp.cur;
                            }
                            change = true;
                            break;
                        }
                    }
                    if (!change)
                    {
                        open[openLength].cur = temp.cur.GetComponent<NodeScript>().around[3];
                        open[openLength].prev = temp.cur;
                        open[openLength].g = temp.cur.GetComponent<NodeScript>().weight + temp.g;
                        open[openLength].h = (int)(Mathf.Abs(temp.cur.transform.position.x + GameObject.Find("End").transform.position.x) + Mathf.Abs(temp.cur.transform.position.z + GameObject.Find("End").transform.position.z));
                        open[openLength].f = open[openLength].g + open[openLength].h;
                        openLength++;
                    }
                }

                for (int x = 0; x < openLength; x++)
                {
                    int switches = 0;
                    for (int k = 1; k < openLength - 1; k++)
                    {
                        if (open[k].f < open[k - 1].f)
                        {
                            Node temOpen = open[k];
                            open[k] = open[k - 1];
                            open[k - 1] = temOpen;
                            switches++;
                        }
                    }
                    if (switches == 0)
                    {
                        break;
                    }
                }
            }
            int place = 0;
            for(int i = 0; i < close.Length; i++)
            {
                if(close[i].cur == GameObject.Find("End"))
                {
                    path = new GameObject[1];
                    place = i;
                    path[0] = close[place].cur;
                    break;
                }
            }
            if(place != 0)
            {
                for(int i = 1; i < close.Length; i++)
                {
                    GameObject[] tempArr = new GameObject[i + 1];
                    for(int x = 0; x < path.Length; x++)
                    {
                        tempArr[x] = path[x];
                    }
                    for(int x = 0;x<close.Length; x++)
                    {
                        if(close[place].prev == close[x].cur)
                        {
                            place = x;
                            break;
                        }
                    }
                    tempArr[i] = close[place].cur;
                    path = tempArr;
                    if(close[place].prev == null)
                    {
                        break;
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.HSVToRGB(1f / 12f, 1, 1);
        if (path != null)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] != null)
                {
                    Gizmos.DrawWireSphere(new Vector3(path[i].transform.position.x + .5f, path[i].transform.position.y + 1, path[i].transform.position.z - .5f), .25f);
                }
                else
                {
                    break;
                }
            }
        }
    }
}