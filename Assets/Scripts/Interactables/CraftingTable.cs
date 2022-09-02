using UnityEngine;

namespace Interactables
{
    public class CraftingTable : MonoBehaviour,IInteractable
    {
        
        //TODO: Make a UI Manager
        public CanvasGroup  canvasGroup;

        public void OnInteract()
        {
            canvasGroup.alpha = 1;
        }
    }
}
