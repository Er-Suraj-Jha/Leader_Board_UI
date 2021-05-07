using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Linq;
using UnityEngine.UI;

public class Object_Pooler : MonoBehaviour
{
    AssetBundle myLoadedAssetBundle;

    public Transform p_transform;
    [Serializable]
    public class Pool
    {
        public string tag;
        public int size;
        public string path;
    }


   #region Singleton

    public static Object_Pooler Instance;
    private void Start()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

   private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool=new Queue<GameObject>();
             myLoadedAssetBundle = AssetBundle.LoadFromFile(pool.path);
              
            int n=2000;
             for(int i=0;i<pool.size;i++)
            {
                var prefab =myLoadedAssetBundle.LoadAsset(pool.tag);
                GameObject obj= Instantiate(prefab) as GameObject;


                obj.transform.SetParent(p_transform,false);
              // obj.transform.SetParent(scrollContent.transform,false);

                TextMeshProUGUI[] texts=obj.GetComponentsInChildren<TextMeshProUGUI>();
                texts[0].text=(i+1).ToString();
                texts[1].text="Player"+UnityEngine.Random.Range(1,100).ToString();
                int m=n-UnityEngine.Random.Range(6,23);
                texts[2].text=m.ToString();
                n=m;

                objectPool.Enqueue(obj);
                obj.SetActive(false);
            }

          poolDictionary.Add(pool.tag,objectPool);
        }
    }


    public GameObject SpawnFromPool(string tag,Vector3 pos)
    {   
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("Entered");
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }
        
        GameObject objectToSpawn =poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position=pos;

        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
