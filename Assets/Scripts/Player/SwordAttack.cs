using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    #region Inspector Fields
    
    [SerializeField] private Collider2D swordCollider;
    
    #endregion
    
    #region Private Fields
    
    private Vector2 rightAttackOffset;
    
    #endregion
    
    #region Unity LifeCycle
    
    private void Start()
    {
        // Get default position of attack offset.
        rightAttackOffset = transform.position;
    }
    
    #endregion

    #region Public Methods
    
    public void AttackRight()
    {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
    }

    public void AttackLeft()
    {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
    }

    public void StopAttack()
    {
        swordCollider.enabled = false;
    }
    
    #endregion
}
