using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    static string willMove = "none";
    static bool movingRed = true;
    enum temp
    {
        continue_, redwin, blackwin
    };
    static temp gameEnd = temp.continue_;

    public static void Select(string name)
    {
        if (willMove == "none" && name.IndexOf(movingRed ? "red" : "black") != -1) willMove = name;
    }

    public static bool CheckSelected(string name)
    {
        return name == willMove;
    }

    public static void Move(string name, Vector3 position_target)
    {
        if ((willMove == name || name == "") && (gameEnd == temp.continue_))
        {
            if (canMove(GameObject.Find(willMove).transform.position, position_target, name))
            {
                GameObject red = GameObject.Find("red-point");
                GameObject black = GameObject.Find("black-point");
                List<GameObject> tnnd = FindObjectWithPosition(position_target);
                bool fxxking = tnnd.Count >= 1 && tnnd[0].name.IndexOf("master") != -1;
                if (fxxking)
                {
                    Debug.Log(tnnd[0].name);

                    if (tnnd[0].name.IndexOf("black") != -1)
                    {
                        gameEnd = temp.redwin;
                        red.transform.position = new Vector3(0, 0, 0);
                        black.transform.position = new Vector3(11.4514f, 19.19f, 8.10f);
                    }
                    else
                    {
                        gameEnd = temp.blackwin;
                        red.transform.position = new Vector3(11.4514f, 19.19f, 8.10f);
                        black.transform.position = new Vector3(0, 0, 0);
                    }
                }
                GameObject.Find(willMove).transform.position = position_target;
                Eat(position_target, willMove);
                movingRed = !movingRed;
                if (movingRed && !fxxking)
                {
                    red.transform.position = new Vector3(-3.5f, 0, 0);
                    black.transform.position = new Vector3(11.4514f, 19.19f, 8.10f);
                }
                else if (!fxxking)
                {
                    red.transform.position = new Vector3(11.4514f, 19.19f, 8.10f);
                    black.transform.position = new Vector3(3.5f, 0, 0);
                }
            }
            willMove = "none";
        }
        else
        {
        }
    }

    public static void Eat(Vector3 position, string exception_)
    {
        // Find object from tag "player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        // For each object in players
        foreach (GameObject player in players)
        {
            // Get position of object
            Vector3 playerPosition = player.transform.position;
            // Check if the object is on the position
            if (position.x == playerPosition.x && position.y == playerPosition.y && player.name != exception_)
            {
                player.transform.position = new Vector3(10, 10, 0.5f);
            }
        }
    }

    public static List<GameObject> FindObjectWithPosition(Vector3 position)
    {
        List<GameObject> objs = new List<GameObject>();
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            Vector3 playerPosition = player.transform.position;
            if (position.x == playerPosition.x && position.y == playerPosition.y)
            {
                objs.Add(player);
            }
        }
        return objs;
    }

    public static bool canMove(Vector3 from, Vector3 to, string name)
    {
        if (name.IndexOf(movingRed ? "red" : "black") == -1) return false;
        Vector3 tnnd = new Vector3(0, 0, 0);
        tnnd.x = Mathf.Abs(from.x - to.x);
        tnnd.y = Mathf.Abs(from.y - to.y);

        if (name.IndexOf("master") != -1)
        {
            // 老将
            // 前后左右一格以内
            if (tnnd.x + tnnd.y <= 1) return true;
            else return false;
        }
        else if (name.IndexOf("shit") != -1)
        {
            // 《皇后》
            // 前后、左右和斜着5格以内
            if (tnnd.x == 0 && tnnd.y <= 5)
            {
                bool flag = true;
                for (float y = from.y + (from.y < to.y ? 1 : -1); y != to.y; y = y + (from.y < to.y ? 1 : -1))
                {
                    List<GameObject> objs = FindObjectWithPosition(new Vector3(from.x, y, from.z));
                    if (objs.Count != 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return true;
                else return false;
            }
            else if (tnnd.x <= 5 && tnnd.y == 0)
            {
                bool flag = true;
                for (float x = from.x + (from.x < to.x ? 1 : -1); x != to.x; x = x + (from.x < to.x ? 1 : -1))
                {
                    List<GameObject> objs = FindObjectWithPosition(new Vector3(x, from.y, from.z));
                    if (objs.Count != 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return true;
                else return false;
            }
            else if (tnnd.x == tnnd.y && tnnd.x <= 5)
            {
                bool flag = true;
                for (float x = from.x + (from.x < to.x ? 1 : -1), y = from.y + (from.y < to.y ? 1 : -1);
                    x != to.x; x = x + (from.x < to.x ? 1 : -1), y = y + (from.y < to.y ? 1 : -1))
                {
                    List<GameObject> objs = FindObjectWithPosition(new Vector3(x, y, from.z));
                    if (objs.Count != 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return true;
                else return false;
            }
            else return false;
        }
        else if (name.IndexOf("elephant") != -1)
        {
            // 象
            // 象走“田”
            if (tnnd.x == tnnd.y && tnnd.x == 2)
            {
                bool flag = true;
                for (float x = from.x + (from.x < to.x ? 1 : -1), y = from.y + (from.y < to.y ? 1 : -1);
                    x != to.x; x = x + (from.x < to.x ? 1 : -1), y = y + (from.y < to.y ? 1 : -1))
                {
                    List<GameObject> objs = FindObjectWithPosition(new Vector3(x, y, from.z));
                    if (objs.Count != 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag) return true;
                else return false;
            }
            else return false;
        }
        else if (name.IndexOf("horse") != -1)
        {
            // 小马驹
            // 马走“日”
            if (tnnd.x == 1 && tnnd.y == 2 || tnnd.x == 2 && tnnd.y == 1)
            {
                Vector3 check;
                switch ((to.x - from.x, to.y - from.y))
                {
                    case (1, 2):
                    case (-1, 2):
                        check = from + new Vector3(0, 1, 0);
                        break;
                    case (1, -2):
                    case (-1, -2):
                        check = from + new Vector3(0, -1, 0);
                        break;
                    case (2, 1):
                    case (2, -1):
                        check = from + new Vector3(1, 0, 0);
                        break;
                    case (-2, 1):
                    case (-2, -1):
                        check = from + new Vector3(-1, 0, 0);
                        break;
                    default:
                        check = from;
                        break;
                }
                return (FindObjectWithPosition(check).Count == 0 ? true : false);
            }
            else return false;
        }
        else if (name.IndexOf("car") != -1)
        {
            // 车
            // 横/竖一条直线随便走
            if (tnnd.x == 0 || tnnd.y == 0)
            {
                if (tnnd.x == 0)
                {
                    bool flag = true;
                    for (float y = from.y + (from.y < to.y ? 1 : -1); y != to.y; y = y + (from.y < to.y ? 1 : -1))
                    {
                        List<GameObject> objs = FindObjectWithPosition(new Vector3(from.x, y, from.z));
                        if (objs.Count != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) return true;
                    else return false;
                }
                else if (tnnd.y == 0)
                {
                    bool flag = true;
                    for (float x = from.x + (from.x < to.x ? 1 : -1); x != to.x; x = x + (from.x < to.x ? 1 : -1))
                    {
                        List<GameObject> objs = FindObjectWithPosition(new Vector3(x, from.y, from.z));
                        if (objs.Count != 0)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag) return true;
                    else return false;
                }
            }
            else return false;
        }
        else if (name.IndexOf("gun") != -1)
        {
            if (tnnd.x == 0 || tnnd.y == 0)
            {
                if (tnnd.x == 0)
                {
                    int flag = 0;
                    for (float y = from.y + (from.y < to.y ? 1 : -1); y != to.y; y = y + (from.y < to.y ? 1 : -1))
                    {
                        List<GameObject> objs = FindObjectWithPosition(new Vector3(from.x, y, from.z));
                        if (objs.Count != 0)
                        {
                            flag++;
                        }
                    }
                    if (FindObjectWithPosition(to).Count == 0)
                    {
                        return flag == 0;
                    }
                    else
                    {
                        return flag == 1;
                    }
                }
                else if (tnnd.y == 0)
                {
                    int flag = 0;
                    for (float x = from.x + (from.x < to.x ? 1 : -1); x != to.x; x = x + (from.x < to.x ? 1 : -1))
                    {
                        List<GameObject> objs = FindObjectWithPosition(new Vector3(x, from.y, from.z));
                        if (objs.Count != 0)
                        {
                            flag = flag + 1;
                        }
                    }
                    if (FindObjectWithPosition(to).Count == 0)
                    {
                        return flag == 0;
                    }
                    else
                    {
                        return flag == 1;
                    }
                }
            }
            else return false;
        }
        else if (name.IndexOf("bing") != -1)
        {
            // 兵
            if (tnnd.x + tnnd.y > 1)
                return false;
            else if (name.IndexOf("red") != -1)
            {
                // 红方
                if (from.y > 0)
                {
                    // 过河
                    switch ((to.x - from.x, to.y - from.y))
                    {
                        case (0, 1):
                        case (1, 0):
                        case (-1, 0):
                            return true;
                        default:
                            return false;

                    }
                }
                else
                {
                    switch ((to.x - from.x, to.y - from.y))
                    {
                        case (0, 1):
                            return true;
                        default:
                            return false;
                    }
                }
            }
            else
            {
                // 黑方
                if (from.y < 0)
                {
                    // 过河
                    switch ((to.x - from.x, to.y - from.y))
                    {
                        case (0, -1):
                        case (1, 0):
                        case (-1, 0):
                            return true;
                        default:
                            return false;
                    }
                }
                else
                {
                    switch ((to.x - from.x, to.y - from.y))
                    {
                        case (0, -1):
                            return true;
                        default:
                            return false;
                    }
                }
            }
        }
        return false;
    }
}
