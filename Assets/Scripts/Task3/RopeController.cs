using UnityEngine;

namespace Assets.Scripts.Task3
{
    public class RopeController : MonoBehaviour {
    
        public Transform LampHandler;

        public LineRenderer LineRenderer;
	
        private void Start ()
        {
            LineRenderer = GetComponent<LineRenderer>();
        }
	
	
        private void LateUpdate ()
        {
            LineRenderer.numPositions = 2;
            LineRenderer.SetPosition(0, transform.position);
            LineRenderer.SetPosition(1, LampHandler.position);
        }
    }
}
