using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PandarooStudios.BeeSim
{
    public class Hive : Singleton<Hive>
    {
        #region Private Variables

        [SerializeField]
        private Vector2 diagOffset;

        private List<Honeycomb> endCombs;

        [SerializeField]
        private Vector2 offset;

        #endregion Private Variables

        #region Properties

        public Vector2 DiagOffset { get { return diagOffset; } }
        public Vector2 OffSet { get { return offset; } }

        #endregion Properties

        #region Public Variables

        public GameObject honeycombPrefab;

        #endregion Public Variables

        #region Monobehaviour Callbacks

        // Start is called before the first frame update
        private void Start()
        {
            endCombs = new List<Honeycomb>();

            if (honeycombPrefab != null)
            {
                // Create first foundation comb
                GameObject newComb = GameObject.Instantiate(honeycombPrefab, transform.position, Quaternion.identity);
                endCombs.Add(newComb.GetComponent<Honeycomb>());
                // Begin honecomb creation coroutinex
                StartCoroutine(CreateComb());
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }

        #endregion Monobehaviour Callbacks

        #region Coroutines

        private IEnumerator CreateComb()
        {
            while (true)
            {
                Honeycomb parentComb = endCombs[Random.Range(0, endCombs.Count - 1)];
                // Create New honeycomb
                GameObject newComb = GameObject.Instantiate(honeycombPrefab, parentComb.GetFreeNeighbor(), Quaternion.identity);
                endCombs.Add(newComb.GetComponent<Honeycomb>());
                if (!parentComb.IsEndComb)
                    endCombs.Remove(parentComb);
                // Wait
                yield return new WaitForSecondsRealtime(Random.Range(0, 3));
            }
        }

        #endregion Coroutines
    }
}