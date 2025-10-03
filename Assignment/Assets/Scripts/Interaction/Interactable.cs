using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractionHandler>() != null) //If the collided object has an interaction handler
        {
            collision.gameObject.GetComponent<InteractionHandler>().SetNewFocus(this); //Set the focused interactable to this
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<InteractionHandler>() != null) //If the collided object has an interaction handler
        {
            collision.gameObject.GetComponent<InteractionHandler>().ClearFocus(); //Clear focus
        }
    }

    public UnityEvent OnInteract;
}
