using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

namespace Assets
{
    [RequireComponent(typeof(Collider))]

    public class FireDestroy : MonoBehaviour
    {
        public GameObject flameObj; // the visual flame
        public GameObject barrier; // the barrier

        private void onTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<FireLightable>())
            {
                if (flameObj.activeSelf == true)
                {
                    Destroy(barrier);
                }
            }
        }
    }
}