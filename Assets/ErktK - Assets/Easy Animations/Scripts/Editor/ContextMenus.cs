using UnityEngine;
using UnityEditor;


public class ContextMenus : EditorWindow
{
    // Open the window from the menu item
    [MenuItem("Example/Anim Item")]
    static void Init()
    {
        EditorWindow window = GetWindow<ContextMenus>();
        window.position = new Rect(50f, 50f, 200f, 24f);
        window.Show();
    }

    // Serialize field on window so its value will be saved when Unity recompiles;
    Color m_Color = Color.white;

    void OnEnable()
    {
        titleContent = new GUIContent("Easy Animations");
    }

    // A method to simplify adding menu items
    void AddMenuItemForAnim(GenericMenu menu, string menuPath, Color color)
    {
        // the menu item is marked as selected if it matches the current value of m_color
        menu.AddItem(new GUIContent(menuPath), m_Color.Equals(color), OnColorSelected, color);
    }

    // the GenericMenu.MenuFunction2 event handler for when a menu item is selected.
    void OnColorSelected(object color)
    {
        m_Color = (Color) color;
    }

    void OnGUI()
    {
        // set the GUI to use the color stored in m_Color
        GUI.color = m_Color;

        // display the GenericMenu when pressing a button
        if (GUILayout.Button("Select GUI Color"))
        {
            // create the menu and add items to it
            GenericMenu menu = new GenericMenu();

            // forward slashes nest menu items under submenus
            AddMenuItemForAnim(menu, "RGB/Red", Color.red);
            AddMenuItemForAnim(menu, "RGB/Green", Color.green);
            AddMenuItemForAnim(menu, "RGB/Blue", Color.blue);
            // an empty string will create a separator at the top level
            menu.AddSeparator("");

            AddMenuItemForAnim(menu, "CMYK/Cyan", Color.cyan);
            AddMenuItemForAnim(menu, "CMYK/Yellow", Color.yellow);
            AddMenuItemForAnim(menu, "CMYK/Magenta", Color.magenta);

            // a trailing slash will nest a separator in a submenu
            menu.AddSeparator("CMYK/");
            AddMenuItemForAnim(menu, "CMYK/Black", Color.black);

            menu.AddSeparator("");

            AddMenuItemForAnim(menu, "White", Color.white);

            // display the menu
            menu.ShowAsContext();
        }
    }
}
