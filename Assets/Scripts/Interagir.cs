using UnityEngine;

public class Interagir : MonoBehaviour
{
    public float interactRange = 2f; // Distância máxima para interação
    public LayerMask interactableLayer; // Layer dos objetos interagíveis

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        // Detecta todos os objetos interagíveis dentro do raio
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange, interactableLayer);

        foreach (Collider2D hit in hits)
        {
            // Procura a interface IInteractable no objeto
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); // Chama a interação
                break; // Interage com apenas um objeto por vez
            }
        }
    }

    // Mostra a área de interação no editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    public interface IInteractable
    {
        void Interact();
    }

}

