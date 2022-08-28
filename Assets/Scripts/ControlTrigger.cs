using UnityEngine;

public class ControlTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            Invoke("_fallPlatform", 0.5f); // trigger _fallPlatform function after 0.5 seconds
        }
    }

    private void _fallPlatform()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        
        Destroy(transform.parent.gameObject, 2f); // destroys ControlTrigger parent (Default Platform) and its children after 2 secs
    }
}
