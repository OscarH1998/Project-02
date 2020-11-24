using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    // TODO build a more structured connection
    public static ITargetable CurrentTarget;
    // interfaces dont serialize, so need class reference
    [SerializeField] Creature _objectToTarget = null;

    public void Target()
    {
     //target teh object if it is targetable
        ITargetable possibleTarget = _objectToTarget.GetComponent<ITargetable>();
        if(possibleTarget != null)
        {
            Debug.Log("New target acquired!");
            CurrentTarget = possibleTarget;
            _objectToTarget.Target();
        }
    }
}
