using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private PlayerMovement playerMovement; 
    private LayerMask layersToDetect;
    private float rayDistance = 5f;
    private void Start()
    {
        layersToDetect = LayerMask.GetMask("Default");
        #region
        playerMovement = GetComponent<PlayerMovement>();
        #endregion
    }
    void Update()
    {
        Physics.Raycast(playerMovement.camTransform.position, playerMovement.camTransform.forward);
        Debug.DrawRay(playerMovement.camTransform.position, playerMovement.camTransform.forward, Color.magenta);
        if (Physics.Raycast(playerMovement.camTransform.position, playerMovement.camTransform.forward, out RaycastHit hit, rayDistance, layersToDetect))
        {
            Debug.Log($"RAYO TOCANDO: {hit.transform.gameObject.name}");
        }
    }
}
