using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Interacting with: " + transform.name);
    }

    public virtual string GetText()
    {
        return "Press 'E' to use " + transform.name;
    }
}
