using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class Table : MonoBehaviour
{
    [SerializeField] private float itemMass;
    private BoxCollider2D boxCollider2D;
    private Animator animator;
    private Rigidbody2D Rigidbody2D;
    private bool itemUsed = false;

    private void Awake() 
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void UseItem()
    {
        if(!itemUsed)
        {
            Bounds bounds = boxCollider2D.bounds;

            Vector3 closestPointToPlayer = bounds.ClosestPoint(GameManager.Instance.GetPlayer().GetPlayerPosition());

            if(closestPointToPlayer.x == bounds.max.x)
            {
                animator.SetBool(Settings.flipLeft, true);
            }
            else if(closestPointToPlayer.x == bounds.min.x)
            {
                animator.SetBool(Settings.flipRight, true);
            }
            else if(closestPointToPlayer.y == bounds.min.y)
            {
                animator.SetBool(Settings.flipUp, true);
            }
            else
            {
                animator.SetBool(Settings.flipDown, true);
            }

            gameObject.layer = LayerMask.NameToLayer("Environment");

            Rigidbody2D.mass = itemMass;

            SoundEffectManager.Instance.PlaySoundEffect(GameResources.Instance.tableFlip);

            itemUsed = true;
        }
    }

    private void OnValidate() 
    {
        HelperUtilities.ValidateCheckPositiveValue(this, nameof(itemMass), itemMass, false);
    }
}
