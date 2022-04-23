using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CharacterScriptableObject", order = 1)]
public class ScriptableCharacters : ScriptableObject
{
    public string prefabName;
    public string background;
    public string inventory;
    public Sprite picture;
    public Transform characterPosition;


}
