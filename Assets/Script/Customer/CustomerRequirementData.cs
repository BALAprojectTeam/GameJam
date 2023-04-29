using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CustomerRequirement")]
public class CustomerRequirementData : ScriptableObject
{
    public List<string> componentLikes;
    public List<string> componentDislikes;

    public List<string> baseTypeLikes;
    public List<string> baseTypedislikes;

    public List<string> tasteLikes;
    public List<string> tasteDislikes;

    public List<string> allergy;
}
