using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_Values : MonoBehaviour
{
    Object_Pooler object_Pooler;
    public int table_start;
    void Start()
    {
        object_Pooler=Object_Pooler.Instance;
        Table_Start(table_start);
        Initialise_Data(object_Pooler,transform.position);
    }


    private void Table_Start(int table_start)
    {
        float x=table_start-35f;
        float y=x*21.20f;
        transform.position = new Vector3(transform.position.x, y , transform.position.z);
    }

    private void Initialise_Data(Object_Pooler object_Pooler,Vector3 pos)
    {
         for(int i=0;i<100;i++)
        {
        object_Pooler.SpawnFromPool("Row",pos);
        }
    }
}
