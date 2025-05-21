using UnityEngine;

[CreateAssetMenu (fileName = "new_dialogue", menuName = "Dialogue")]
public class SO_Dialogue : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        [TextAreaAttribute(4, 8)] public string dialogue;
    }
    public Info[] dialogueInfo;


}
