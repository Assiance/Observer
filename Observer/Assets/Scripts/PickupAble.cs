using UnityEngine;

public class PickupAble : MonoBehaviour
{
    public void interact()
    {
        var transform = this.GetComponent<Transform>();
        var playerTransform = SceneManager.Instance.Player.GetComponent<Interact>().transform;
        transform.Translate(Vector3.zero);
    }


}

