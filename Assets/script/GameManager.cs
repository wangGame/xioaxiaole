using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //甜品类型
    public enum SweetsType {
        EMPTY  ,
        NORMAL,
        BARRIEAR,
        ROW_CLEAR,
        COLUMN_CLEAR,
        BAINBOWCANDY,
        COUNT
    }

    //甜品字典  通过甜品的种类得到甜品的游戏物体
    private Dictionary<SweetsType, GameObject> sweetPrefabDict;
    
    [System.Serializable]
    public struct SweetPrefab {
        public SweetsType type;
        public GameObject prefab;
    }

    public SweetPrefab[] sweetPrefab;  
    //创建 行列个数
    public int xColumn;
    public int yRow;

    //我们需要创建一个格子块，通过预制体创建
    public GameObject black;

    //create 单例方法
    private static GameManager _instance;

    // 二维数组
    private GameObject[,] sweets;

    public static GameManager instance {
        get {
            return _instance;
        }

        set {
            _instance = value;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        sweetPrefabDict = new Dictionary<SweetsType, GameObject>();
        for (int i = 0; i < sweetPrefab.Length; i++) {
            if (!sweetPrefabDict.ContainsKey(sweetPrefab[i].type)) {
                sweetPrefabDict.Add(sweetPrefab[i].type,sweetPrefab[i].prefab);
            }
        }


        for (int x = 0; x < xColumn; x++) {
            for (int y = 0; y < yRow; y++) {
                //不旋转
                GameObject gameObject = Instantiate(black, convertPosition(x,y), Quaternion.identity);
                gameObject.transform.SetParent(transform);
            }
        }

        //实例化
        sweets = new GameObject[xColumn,yRow];
        for (int x = 0; x < xColumn; x++)
        {
            for (int y = 0; y < yRow; y++)
            {
                //不旋转
                sweets[x,y] = Instantiate(sweetPrefabDict[SweetsType.NORMAL],
                    convertPosition(x, y), Quaternion.identity);
                sweets[x,y].transform.SetParent(transform);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 convertPosition(int x,int y) {
        return new Vector3(x - xColumn / 2+ transform.position.x,
            y - yRow/2 + transform.position.y);
    }
}
