using UnityEngine;
using TMPro;

public class PlayerInteractions : MonoBehaviour
{
    private PlayerMovement playerMovement; 
    private LayerMask layersToDetect;
    private TextMeshProUGUI interactionText;
    private float rayDistance = 10f;
    private void Start()
    {
        interactionText = GameObject.Find("Interaction Text").GetComponent<TextMeshProUGUI>();
        layersToDetect = LayerMask.GetMask("Default");
        playerMovement = GetComponent<PlayerMovement>();
        interactionText.text = null;
    }
    void Update()
    {
        if (Physics.Raycast(playerMovement.camTransform.position, playerMovement.camTransform.forward, out RaycastHit hit, rayDistance, layersToDetect))
        {
            interactionText.text = hit.transform.gameObject.name;
            Debug.DrawRay(playerMovement.camTransform.position, playerMovement.camTransform.forward, Color.green);
        }
        else
        {
            interactionText.text = null;
            Debug.DrawRay(playerMovement.camTransform.position, playerMovement.camTransform.forward, Color.red);
        }
    }
}
