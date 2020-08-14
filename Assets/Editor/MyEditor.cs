using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine.UI;

public class MyEditor
{
    // Add a menu item to create custom GameObjects.
    // Priority 1 ensures it is grouped with the other menu items of the same kind
    // and propagated to the hierarchy dropdown and hierarchy context menus.
    [MenuItem("GameObject/MyCategory1234/Raw Image", false, 10)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        // Create a custom game object
        GameObject go = new GameObject("Custom Game Object");
        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
        Selection.activeObject = go;
    }


    [MenuItem("GameObject/MyCategory1234/Text", false, 10)]
    static public void AddText(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateText(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    [MenuItem("GameObject/MyCategory1234/Image", false, 2001)]
    static public void AddImage(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateImage(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    //[MenuItem("GameObject/MyCategory123/Raw Image", false, 2002)]
    //static public void AddRawImage(MenuCommand menuCommand)
    //{
    //    GameObject go;
    //    using (new FactorySwapToEditor())
    //        go = DefaultControls.CreateRawImage(MenuOptions.GetStandardResources());
    //    MenuOptions.PlaceUIElementRoot(go, menuCommand);
    //}

    // Controls

    // Button and toggle are controls you just click on.

    [MenuItem("GameObject/MyCategory1234/Button", false, 2030)]
    static public void AddButton(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateButton(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    [MenuItem("GameObject/MyCategory1234/Toggle", false, 2031)]
    static public void AddToggle(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateToggle(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    // Slider and Scrollbar modify a number

    [MenuItem("GameObject/MyCategory1234/Slider", false, 2033)]
    static public void AddSlider(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateSlider(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    [MenuItem("GameObject/MyCategory1234/Scrollbar", false, 2034)]
    static public void AddScrollbar(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateScrollbar(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    // More advanced controls below

    [MenuItem("GameObject/MyCategory1234/Dropdown", false, 2035)]
    static public void AddDropdown(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateDropdown(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    [MenuItem("GameObject/MyCategory1234/Input Field", false, 2036)]
    public static void AddInputField(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateInputField(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }

    // Containers

    [MenuItem("GameObject/MyCategory1234/Canvas", false, 2060)]
    static public void AddCanvas(MenuCommand menuCommand)
    {
        var go = MenuOptions.CreateNewUI();
        MenuOptions.SetParentAndAlign(go, menuCommand.context as GameObject);
        if (go.transform.parent as RectTransform)
        {
            RectTransform rect = go.transform as RectTransform;
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.anchoredPosition = Vector2.zero;
            rect.sizeDelta = Vector2.zero;
        }
        Selection.activeGameObject = go;
    }

    [MenuItem("GameObject/MyCategory1234/Panel", false, 2061)]
    static public void AddPanel(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreatePanel(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);

        // Panel is special, we need to ensure there's no padding after repositioning.
        RectTransform rect = go.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.zero;
        rect.sizeDelta = Vector2.zero;
    }

    [MenuItem("GameObject/MyCategory1234/Scroll View", false, 2062)]
    static public void AddScrollView(MenuCommand menuCommand)
    {
        GameObject go;
        using (new FactorySwapToEditor())
            go = DefaultControls.CreateScrollView(MenuOptions.GetStandardResources());
        MenuOptions.PlaceUIElementRoot(go, menuCommand);
    }
}
