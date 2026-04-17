using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

// Extend EditorWindow to create your own customEditor windows
public class EditorWindowExample : EditorWindow
{
    // Create a new menu item in the Unity Menu Bar to open our Window. 
    // The menu item will be located at Tools > My Editor Window
    [MenuItem("Tools/Editor Window Example")] 
    public static void OpenEditorWindow()
    {
        EditorWindowExample wnd = GetWindow<EditorWindowExample>();
        wnd.titleContent = new GUIContent("Editor Window Title");       
        
        wnd.maxSize = new Vector2(440, 350);
        wnd.minSize = wnd.maxSize;
    }

    public void CreateGUI()
    {
        // CreateGUI is called when the EditorWindow's rootVisualElement is ready to be populated.
        // Use CreateGUI to add UI Toolkit UI elements to your window.
        // https://docs.unity3d.com/6000.4/Documentation/ScriptReference/EditorWindow.CreateGUI.html

        // Each editor window contains a root VisualElement object            
        VisualElement root = rootVisualElement;

        // The UXML file holds the UI structure for the editor window (editable in Unity with Window > UI Toolkit > UI Builder)
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/EditorWindowExample/Resources/UI Documents/EditorWindowExample.uxml");        
        
        VisualElement tree = visualTree.Instantiate();
        root.Add(tree);

        // Edit UI elements defined in UXML
        root.Q<Label>("title").text = "Editor Window Example";
        root.Q<Label>("description").text = "This is an example of an Editor Window created with UI Toolkit.";

        // Create button
        Button button = new()
        {
            name = "button",
            text = "Programmatically added button"
        };
        root.Add(button);

        // Create toggle
        Toggle toggle = new()
        {
            name = "toggle",
            label = "Programmatically added toggle"
        };
        root.Add(toggle);

        // register Callbacks for UI elements with custom code:
        toggle.RegisterValueChangedCallback(MyToggleBehavior);
        button.clicked += () => MyButtonBehavior();
    }

    public void MyToggleBehavior(ChangeEvent<bool> evt)
    {
        Debug.Log($"Toggle value changed to {evt.newValue}");
    }

    public void MyButtonBehavior()
    {        
        Debug.Log("Button clicked!");
    }

    public void Update()
    {        
        // Called multiple times per second on all visible windows.
        // https://docs.unity3d.com/6000.4/Documentation/ScriptReference/EditorWindow.Update.html
    }

    public void OnGUI()
    {
        // Use OnGUI to draw all the controls of your window.
        // Called multiple times per frame for rendering and handling GUI events.
        // https://docs.unity3d.com/6000.4/Documentation/ScriptReference/EditorWindow.OnGUI.html
    }

    public void OnEnable()
    {
        // Called when the script is loaded or when the object is enabled.
        // https://docs.unity3d.com/6000.4/Documentation/ScriptReference/ScriptableObject.OnEnable.html
    }
    public void OnDisable()
    {
        // Called when the script is disabled or the object is destroyed to finalize and clean up resources.
        // https://docs.unity3d.com/6000.4/Documentation/ScriptReference/ScriptableObject.OnDisable.html
    }
}    

