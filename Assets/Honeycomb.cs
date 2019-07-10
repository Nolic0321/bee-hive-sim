using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.PandarooStudios.BeeSim
{
    public class Honeycomb : MonoBehaviour
    {
        #region Private Variables

        [SerializeField]
        private bool endComb = true;

        #endregion Private Variables

        #region Properties

        public bool IsEndComb
        {
            get
            {
                return endComb;
            }
        }

        #endregion Properties

        #region Private Methods

        private bool EndCombCheck()
        {
            return true;
        }

        #endregion Private Methods
    }
}