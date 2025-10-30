using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public Interactable CurrentFocus {  get; private set; }

    private void Awake()
    {
        InputManager.instance.interactEvent.AddListener(InteractWithCurrentFocus); //Add listener to inpout event
    }

    private void OnDestroy()
    {
        InputManager.instance.interactEvent.RemoveListener(InteractWithCurrentFocus); //remove listener from input event
    }

    public void SetNewFocus(Interactable newFocus) //Triggered by Interactable on collision
    {
        CurrentFocus = newFocus;
        HudManager.activeInstance.EnableTooltip();
    }

    public void ClearFocus() //Triggered by interactable on collision exit
    {
        CurrentFocus = null;
        if (HudManager.activeInstance != null)
        {
            HudManager.activeInstance.DisableTooltip();
        }
    }

    public void InteractWithCurrentFocus() //Triggered by InputManager when iteractionInputEvent is called
    {
        if (CurrentFocus != null) 
        {
            CurrentFocus.OnInteract.Invoke();
            AudioManager.Instance.PlaySound("Click_Sound");
        }
    }
}
