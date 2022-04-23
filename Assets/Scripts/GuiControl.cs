using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Game.Gameplay.GameManager;
public class GuiControl : MonoBehaviour
{
    private Button startButton;
    private VisualElement mainMenu;
    private VisualElement selectCharacter;
    private VisualElement root;
    private TextField inventory;
    private TextField background;
    private IMGUIContainer picture;
    private List<ScriptableCharacters> charactersInGame;
    private ScriptableCharacters currentCharacter;
   
    [SerializeField] private ScriptableCharacters oldMan;

    private void OnEnable()
    {
        EventManager.StartListening("CharacterSpawned", OnCharacterSpawned);

    }
    private void OnDisable()
    {
        EventManager.StopListening("CharacterSpawned", OnCharacterSpawned);
    }
    private void Awake()
    {
        charactersInGame = new List<ScriptableCharacters>();
    }

    void Start()
    {
      
        root= GetComponent<UIDocument>().rootVisualElement;
        mainMenu = root.Q<VisualElement>("ContainerUI");
        selectCharacter = root.Q<VisualElement>("ContainerSelectCharacter");
        inventory= root.Q<TextField>("Inventory");
        background= root.Q<TextField>("Background");
        picture = root.Q<IMGUIContainer>("Picture");

       
        AddEventsMainMenu();
        AddEventsSelectCharacterMenu();


    }


    private void AddEventsMainMenu()
    {
        
        root.Q<Button>("ButtonStart").clicked += OnClickedStart;

      
    }

    private void AddEventsSelectCharacterMenu()
    {
       
        root.Q<Button>("BackToMenu").clicked += OnclickedBackToMenu;
         root.Q<Button>("ButtonBack").clicked += OnClickedBackButton;
        /* root.Q<Button>("ButtonSelect").clicked += OnClickedStart;*/
        root.Q<Button>("ButtonNext").clicked += OnClickedNextCharacter;
    }
    private void OnClickedStart()
    {
        mainMenu.style.display=DisplayStyle.None;
        selectCharacter.style.display = DisplayStyle.Flex;
        AddInfosCharacter(charactersInGame[0]);
    }
    private void OnclickedBackToMenu()
    {
        selectCharacter.style.display = DisplayStyle.None;
        mainMenu.style.display = DisplayStyle.Flex;
        ResetTarget();
    }
    private void OnClickedNextCharacter()
    {
        int current = charactersInGame.IndexOf(currentCharacter);
        if (current >= charactersInGame.Count-1)
            return;
        current++;
        currentCharacter = charactersInGame[current];
        AddInfosCharacter(charactersInGame[current]);
    }
    private void AddInfosCharacter(ScriptableCharacters characters)
    {
        picture.style.backgroundImage =new StyleBackground(characters.picture);
        inventory.value = characters.inventory;
        background.value = characters.background;
        ChangeTarget(characters.characterPosition);
    }
    private void ChangeTarget(Transform target)
    {
        EventManager.TriggerEvent("ChangedTarget", target);
    }
    private void OnClickedBackButton()
    {
        int current = charactersInGame.IndexOf(currentCharacter);
        if (current <= 0)
            return;
        current--;
        currentCharacter = charactersInGame[current];
        AddInfosCharacter(charactersInGame[current]);
    }
    private void OnCharacterSpawned(object character)
    {
        charactersInGame.Add((ScriptableCharacters)character);
        
    }
    private void ResetTarget()
    {
        EventManager.TriggerEvent("ResetTarget");
    }
}
