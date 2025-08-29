using UnityEngine;

public class Interagir : MonoBehaviour
{
    public float interactRange = 2f; // Dist�ncia m�xima para intera��o
    public LayerMask interactableLayer; // Layer dos objetos interag�veis

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        // Detecta todos os objetos interag�veis dentro do raio
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange, interactableLayer);

        foreach (Collider2D hit in hits)
        {
            // Procura a interface IInteractable no objeto
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact(); // Chama a intera��o
                break; // Interage com apenas um objeto por vez
            }
        }
    }

    // Mostra a �rea de intera��o no editor
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

