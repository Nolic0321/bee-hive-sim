using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Com.PandarooStudios.BeeSim
{
    public class Honeycomb : MonoBehaviour
    {
        #region Private Variables

        private bool foundation = false;
        private Vector2 left;
        private Vector2 lowerLeft;
        private Vector2 lowerRight;

        [SerializeField]
        private LayerMask neighborCheckLayer;

        private int neighbors = 0;
        private Vector2 right;
        private Vector2 upperLeft;
        private Vector2 upperRight;

        #endregion Private Variables

        #region Monobehaviour Callbacks

        private void Awake()
        {
            // Get Neighbor Vectors Set

            right = Hive.Instance.OffSet;
            left = -right;
            lowerRight = Hive.Instance.DiagOffset;
            upperLeft = -lowerRight;
            lowerLeft = new Vector2(-lowerRight.x, lowerRight.y);
            upperRight = -lowerLeft;

            // Check if we're a foundation comb
            if (transform.localPosition.y == 0 || transform.localPosition.y == (0 + Hive.Instance.DiagOffset.y))
                foundation = true;
        }

        #endregion Monobehaviour Callbacks

        #region Properties

        public bool IsEndComb
        {
            get
            {
                EndCombCheck();
                return foundation ? neighbors < 4 : neighbors < 6;
            }
        }

        #endregion Properties

        #region Private Methods

        private void EndCombCheck()
        {
            Collider2D[] results = new Collider2D[7];
            Physics2D.OverlapCircleNonAlloc((Vector2)transform.position, 1.2f, results, neighborCheckLayer);
            neighbors = results.Where(x => x != null).Count() - 1;
        }

        #endregion Private Methods

        #region Public Methods

        public Vector2 GetFreeNeighbor()
        {
            Collider2D[] results = new Collider2D[7];
            Physics2D.OverlapCircleNonAlloc((Vector2)transform.position, 1.2f, results, neighborCheckLayer);
            List<Vector2> neighbors = foundation ? new List<Vector2> { left, right, lowerLeft, lowerRight } : new List<Vector2> { left, right, lowerLeft, lowerRight, upperLeft, upperRight };
            for (int i = 0; i < results.Where(x => x != null).Count() - 1; i++)
            {
                Vector2 diff = results[i].transform.position - transform.position;
                neighbors.Remove(diff);
            }

            return neighbors[Random.Range(0, neighbors.Count == 0 ? 0 : neighbors.Count - 1)];
        }

        #endregion Public Methods
    }
}