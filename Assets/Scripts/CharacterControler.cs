using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Gameplay.GameManager;
public class CharacterControler : MonoBehaviour
{
    [SerializeField]private ScriptableCharacters character;
    [SerializeField] private Transform targetPoint;
    void Start()
    {
        character.characterPosition = targetPoint;
        EventManager.TriggerEvent("CharacterSpawned", character);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
