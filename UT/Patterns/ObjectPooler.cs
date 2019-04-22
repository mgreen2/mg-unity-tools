using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG.UT.Patterns
{
    public class ObjectPooler : MonoBehaviour
    {
        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictio;
        // Start is called before the first frame update
        public float f;

        void Start()
        {
            poolDictio = new Dictionary<string, Queue<GameObject>>();

            foreach(Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictio.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 pos, Quaternion rot)
        {
            if (!poolDictio.ContainsKey(tag)) {
                return null;
            }

            GameObject objectToSpawn = poolDictio[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.SetPositionAndRotation(pos, rot);

            IPoolable poolable = objectToSpawn.GetComponent<IPoolable>();
            poolable.OnObjectSpawn();

            poolDictio[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }

      

        // Update is called once per frame
        void Update()
        {
            // f: Float = 5
            // DoSomething(foo: string, bar: float, you: person): RaycastHit
            // DoSomething: RaycastHit(foo: string, bar: float, you: person)
            // RaycastHit DoSomething(foo: string, bar: float,  you: preson)
            // func 

            // [anything] name
            // AWholeBunchOfShit() : Type
        }

        [System.Serializable]
        public class Pool
        {
            public string tag;
            public GameObject prefab;
            public int size;
        }
    }

    public interface IPoolable
    {
        void OnObjectSpawn();
    }
}