using UnityEngine;

namespace DefaultNamespace {
    public class FixedUpdateMovement  : MonoBehaviour{
        private Vector3 movement = new Vector3(0.1f, 0, 0);
        void FixedUpdate() {    
            transform.localPosition = transform.localPosition + movement;
            //transform.Rotate(new Vector3(0, 0.7f, 0));
        }
    }
}