using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PandarooStudios.BeeSim
{
    public class Hive : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        private Vector2 diagOffset;

        private List<GameObject> endCombs;

        [SerializeField]
        private Vector2 offset;

        #endregion Private Variables

        #region Public Variables

        public GameObject honeycombPrefab;

        #endregion Public Variables

        #region Monobehaviour Callbacks

        // Start is called before the first frame update
        private void Start()
        {
            endCombs = new List<GameObject>();
            if (honeycombPrefab != null)
            {
                // Begin honecomb creation coroutine
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
                // Create New honeycomb
                // Wait
            }
        }

        #endregion Coroutines
    }
}