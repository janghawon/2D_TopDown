using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorInHierarchy : MonoBehaviour
{
#if UNITY_EDITOR
    private static Dictionary<Object, ColorInHierarchy> _coloredobjects = new Dictionary<Object, ColorInHierarchy>();

    static ColorInHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleDraw;
    }

    private static void HandleDraw(int instanceID, Rect selectionRect)
    {
        Object obj = EditorUtility.InstanceIDToObject(instanceID);

        if(obj != null && _coloredobjects.ContainsKey(obj))
        {
            GameObject gameobj = obj as GameObject;
            ColorInHierarchy cih = gameobj.GetComponent<ColorInHierarchy>();
            if(cih != null)
            {
                PaintObject(obj, selectionRect, cih);
            }
            else
            {
                _coloredobjects.Remove(obj);
            }
        }
    }

    public static void PaintObject(Object obj, Rect selectionRect, ColorInHierarchy cih)
    {
        Rect bgRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width + 50f, selectionRect.height);
        if(Selection.activeObject != obj)
        {
            EditorGUI.DrawRect(bgRect, cih.backColor);
            string name = $"{cih.prefix} {obj.name}";

            EditorGUI.LabelField(bgRect, name, new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = cih.fontColor },
                fontStyle = FontStyle.Normal,
            }) ;
        }
    }

    public string prefix;
    public Color backColor;
    public Color fontColor;

    private void Reset()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        if(_coloredobjects.ContainsKey(this.gameObject) == false)
        {
            _coloredobjects.Add(this.gameObject, this);
        }
    }
#endif
}
