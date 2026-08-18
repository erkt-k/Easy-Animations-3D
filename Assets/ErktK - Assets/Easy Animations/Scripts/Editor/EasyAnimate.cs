using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using System;

[CustomEditor(typeof(EasyAnimationPlayer))]
public class EasyAnimate : Editor
{
    private Type m_ComponentToAdd;
    private EasyAnimationPlayer eaPlayer;
    void OnEnable()
    {
        if (eaPlayer == null) eaPlayer = (EasyAnimationPlayer) target;
    }

    void AddMenuItem(GenericMenu menu, string menuPath, Type type)
    {
        if (m_ComponentToAdd == null) m_ComponentToAdd = typeof(Null);
        menu.AddItem(
            new GUIContent(menuPath), // Content to add (the path in this case)
            m_ComponentToAdd.Equals(type), // Should I put a tick next to it? (yes if it is the component selected)
            OnComponentSelected, type); // The funct to call when an item is selected and it's param
    }

    void OnComponentSelected(object component)
    {
        m_ComponentToAdd = component.GetType();

        if (eaPlayer == null) eaPlayer = (EasyAnimationPlayer) target;
        if (m_ComponentToAdd != null) eaPlayer.gameObject.AddComponent(m_ComponentToAdd);
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        // Get the component from target
        if(eaPlayer == null) eaPlayer = (EasyAnimationPlayer) target;

        GUILayout.Label("Animations", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Add Animation", GUILayout.Width(100));

        // Draw the dropdown button
        if (EditorGUILayout.DropdownButton(new GUIContent("Select an animation to add"),
                                    FocusType.Keyboard,
                                    EditorStyles.popup))
        {
            GenericMenu menu = new GenericMenu();

            AddMenuItem(menu, "Select", typeof(Null));

            menu.AddSeparator("");

            AddMenuItem(menu, "AudioMixer/DOSetFloat", typeof(EasyAudioMixerSetFloat));

            menu.AddSeparator("");

            AddMenuItem(menu, "AudioSource/DOFade", typeof(EasyAudioSourceFade));
            AddMenuItem(menu, "AudioSource/DOPitch", typeof(EasyAudioSourcePitch));

            menu.AddSeparator("");

            AddMenuItem(menu, "Camera/DOAspect", typeof(EasyCameraAspect));
            AddMenuItem(menu, "Camera/DOColor", typeof(EasyCameraColor));
            AddMenuItem(menu, "Camera/DOFarClipPlane", typeof(EasyCameraFarClipPlane));
            AddMenuItem(menu, "Camera/DOFieldOfView", typeof(EasyCameraFieldOfView));
            AddMenuItem(menu, "Camera/DONearClipPlane", typeof(EasyCameraNearClipPlane));
            AddMenuItem(menu, "Camera/DOOrthoSize", typeof(EasyCameraOrthoSize));
            AddMenuItem(menu, "Camera/DOPixelRect", typeof(EasyCameraPixelRect));
            AddMenuItem(menu, "Camera/DORect", typeof(EasyCameraRect));
            AddMenuItem(menu, "Camera/DOShakePosition", typeof(EasyCameraShakePosition));
            AddMenuItem(menu, "Camera/DOShakeRotation", typeof(EasyCameraShakeRotation));

            menu.AddSeparator("");

            AddMenuItem(menu, "Light/DOColor", typeof(EasyLightColor));
            AddMenuItem(menu, "Light/DOIntensity", typeof(EasyLightIntensity));
            AddMenuItem(menu, "Light/DOShadowStrength", typeof(EasyLightShadowStrength));

            AddMenuItem(menu, "Light/Blendable Tweens/DOBlendableColor", typeof(EasyLightBlendableColor));

            menu.AddSeparator("");

            AddMenuItem(menu, "LineRenderer/DOColor", typeof(EasyLineRendererColor));
/*
            menu.AddSeparator("");

            AddMenuItem(menu, "Material/DOColor", "DOColor");
            AddMenuItem(menu, "Material/DOFade", "DOFade");
            AddMenuItem(menu, "Material/DOFloat", "DOFloats");
            AddMenuItem(menu, "Material/DOGradientColor", "DOGradientColor");
            AddMenuItem(menu, "Material/DOOffset", "DOOffset");
            AddMenuItem(menu, "Material/DOTiling", "DOTiling");
            AddMenuItem(menu, "Material/DOVector", "DOVector");
            
            menu.AddSeparator("Material/");

            AddMenuItem(menu, "Material/Blendable Tweens/DOBlendableColor", "DOBlendableColor");

            menu.AddSeparator("");

            AddMenuItem(menu, "Rigidbody/Move/DOMove", );
            AddMenuItem(menu, "Rigidbody/Move/DOMoveX", "DOMoveX");
            AddMenuItem(menu, "Rigidbody/Move/DOMoveY", "DOMoveY");
            AddMenuItem(menu, "Rigidbody/Move/DOMoveZ", "DOMoveZ");
            AddMenuItem(menu, "Rigidbody/Move/DOJump", "DOJump");

            menu.AddSeparator("Rigidbody/");
            
            AddMenuItem(menu, "Rigidbody/Rotate/DORotate", "DORotate");
            AddMenuItem(menu, "Rigidbody/Rotate/DOLookAt", "DOLookAt");

            menu.AddSeparator("Rigidbody/");

            AddMenuItem(menu, "Rigidbody/Path/DOPath", "DOPath");
            AddMenuItem(menu, "Rigidbody/Path/DOLocalPath", "DOLocalPath");

            menu.AddSeparator("Rigidbody/");

            AddMenuItem(menu, "Rigidbody/Pro Only/DOSpiral", "DOSpiral");

            menu.AddSeparator("");

            AddMenuItem(menu, "Rigidbody2D/Move/DOMove", "DOMove");
            AddMenuItem(menu, "Rigidbody2D/Move/DOMoveX", "DOMoveX");
            AddMenuItem(menu, "Rigidbody2D/Move/DOMoveY", "DOMoveY");
            AddMenuItem(menu, "Rigidbody2D/Move/DOJump", "DOJump");

            menu.AddSeparator("Rigidbody2D/");
            
            AddMenuItem(menu, "Rigidbody2D/Rotate/DORotate", "DORotate");

            menu.AddSeparator("Rigidbody2D/");

            AddMenuItem(menu, "Rigidbody2D/Path/DOPath", "DOPath");
            AddMenuItem(menu, "Rigidbody2D/Path/DOLocalPath", "DOLocalPath");

            menu.AddSeparator("");

            AddMenuItem(menu, "SpriteRenderer/DOColor", "DOColor");
            AddMenuItem(menu, "SpriteRenderer/DOFade", "DOFade");
            AddMenuItem(menu, "SpriteRenderer/DOGradientColor", "DOGradientColor");

            menu.AddSeparator("SpriteRenderer/");

            AddMenuItem(menu, "SpriteRenderer/Blendable Tweens/DOBlendableColor", "DOBlendableColor");

            menu.AddSeparator("");

            AddMenuItem(menu, "TrailRenderer/DOResize", "DOResize");
            AddMenuItem(menu, "TrailRenderer/DOTime", "DOTime");
*/
            menu.AddSeparator("");

            AddMenuItem(menu, "Transform/Move/DOMove", typeof(EasyTransformMove));
            AddMenuItem(menu, "Transform/Move/DOMoveXYZ", typeof(EasyTransformMoveXYZ));

            AddMenuItem(menu, "Transform/Move/DOLocalMove", typeof(EasyTransformLocalMove));
            AddMenuItem(menu, "Transform/Move/DOLocalMoveXYZ", typeof(EasyTransformLocalMoveXYZ));

/*
            AddMenuItem(menu, "Transform/Move/DOJump", "DOJump");
            AddMenuItem(menu, "Transform/Move/DOLocalJump", "DOLocalJump"); 
*/
            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/Rotate/DORotate", typeof(EasyTransformRotateAngles));
            AddMenuItem(menu, "Transform/Rotate/DOLocalRotate", typeof(EasyTransformRotateLocalAngles));
/*
            AddMenuItem(menu, "Transform/Rotate/DOLookAt", "DOLookAt");
            AddMenuItem(menu, "Transform/Rotate/DODynamicLookAt", "DODynamicLookAt");
*/

            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/Scale/DOScale", typeof(EasyTransformScale));
            AddMenuItem(menu, "Transform/Scale/DOScaleXYZ", typeof(EasyTransformScaleXYZ));

            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/Punch/DOPunchPosition", typeof(EasyPunchPosition));
            AddMenuItem(menu, "Transform/Punch/DOPunchRotation", typeof(EasyPunchRotation));
            AddMenuItem(menu, "Transform/Punch/DOPunchScale", typeof(EasyPunchScale));

            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/Shake/DOShakePosition", typeof(EasyShakePosition));
            AddMenuItem(menu, "Transform/Shake/DOShakeRotation", typeof(EasyShakeRotation));
            AddMenuItem(menu, "Transform/Shake/DOShakeScale", typeof(EasyShakeScale));
/*
            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/Path/DOPath", "DOPath");
            AddMenuItem(menu, "Transform/Path/DOLocalPath", "DOLocalPath");

            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/Blendable Tweens/DOBlendableMoveBy", "DOBlendableMoveBy");
            AddMenuItem(menu, "Transform/Blendable Tweens/DOBlendableLocalMoveBy", "DOBlendableLocalMoveBy");
            AddMenuItem(menu, "Transform/Blendable Tweens/DOBlendableRotateBy", "DOBlendableRotateBy");
            AddMenuItem(menu, "Transform/Blendable Tweens/DOBlendableLocalRotateBy", "DOBlendableLocalRotateBy");
            AddMenuItem(menu, "Transform/Blendable Tweens/DOBlendableScaleBy", "DOBlendableScaleBy");

            menu.AddSeparator("Transform/");

            AddMenuItem(menu, "Transform/PRO Only/Spiral/DOSpiral", "DOSpiral");

            menu.AddSeparator("");

            AddMenuItem(menu, "Tween/DOTimeScale", "DOTimeScale");
*/
            menu.AddSeparator("");

            AddMenuItem(menu, "CanvasGroup/DOFade", typeof(EasyCanvasGroupFade));

            menu.AddSeparator("");

            AddMenuItem(menu, "Graphic/DOColor", typeof(EasyGraphicColor));
            AddMenuItem(menu, "Graphic/DOFade", typeof(EasyGraphicFade));
/*
            menu.AddSeparator("Graphic/");

            AddMenuItem(menu, "Graphic/BlendableTweens/DOBlendableColor", "DOBlendableColor");
*/
            menu.AddSeparator("");

            AddMenuItem(menu, "Image/DOColor", typeof(EasyImageColor));
            AddMenuItem(menu, "Image/DOFade", typeof(EasyImageFade));
            AddMenuItem(menu, "Image/DOFillAmount", typeof(EasyImageFillAmount));
//            AddMenuItem(menu, "Image/DOGradientColor", "DOGradientColor");

            menu.AddSeparator("Image/");

            AddMenuItem(menu, "Image/Blendable Tweens/DOBlendableColor", typeof(EasyImageBlendableColor));

            menu.AddSeparator("");

            AddMenuItem(menu, "LayoutElement/DOFlexibleSize", typeof(EasyLayoutElementFlexibleSize));
            AddMenuItem(menu, "LayoutElement/DOMinSize", typeof(EasyLayoutElementMinSize));
            AddMenuItem(menu, "LayoutElement/DOPrefferedSize", typeof(EasyLayoutElementPrefferedSize));

            menu.AddSeparator("");

            AddMenuItem(menu, "Outline/DOColor", typeof(EasyOutlineColor));
            AddMenuItem(menu, "Outline/DOFade", typeof(EasyOutlineFade));
/*
            menu.AddSeparator("");

            AddMenuItem(menu, "RectTransform/DOAnchorMax", "DOAnchorMax");
            AddMenuItem(menu, "RectTransform/DOAnchorMin", "DOAnchorMin");
            AddMenuItem(menu, "RectTransform/DOAnchorPos", "DOAnchorPos");
            AddMenuItem(menu, "RectTransform/DOAnchorPosX", "DOAnchorPosX");
            AddMenuItem(menu, "RectTransform/DOAnchorPosY", "DOAnchorPosY");
            AddMenuItem(menu, "RectTransform/DOAnchorPos3D", "DOAnchorPos3D");
            AddMenuItem(menu, "RectTransform/DOAnchorPos3DX", "DOAnchorPos3DX");
            AddMenuItem(menu, "RectTransform/DOAnchorPos3DY", "DOAnchorPos3DY");
            AddMenuItem(menu, "RectTransform/DOAnchorPos3DZ", "DOAnchorPos3DZ");
            AddMenuItem(menu, "RectTransform/DOJumpAnchorPos", "DOJumpAnchorPos");
            AddMenuItem(menu, "RectTransform/DOPivot", "DOPivot");
            AddMenuItem(menu, "RectTransform/DOPivotX", "DOPivotX");
            AddMenuItem(menu, "RectTransform/DOPivotY", "DOPivotY");
            AddMenuItem(menu, "RectTransform/DOPunchAnchorPos", "DOPunchAnchorPos");
            AddMenuItem(menu, "RectTransform/DOShakeAnchorPos", "DOShakeAnchorPos");
            AddMenuItem(menu, "RectTransform/DOSizeDelta", "DOSizeDelta");
            
            menu.AddSeparator("RectTransform/");
            
            AddMenuItem(menu, "RectTransform/Shape Tweens/DOShapeCircle", "DOShapeCircle");

            menu.AddSeparator("");

            AddMenuItem(menu, "ScrollRect/DONormalizedPos", "DONormalizedPos");
            AddMenuItem(menu, "ScrollRect/DOHorizontalNormalizedPos", "DOHorizontalNormalizedPos");
            AddMenuItem(menu, "ScrollRect/DOVerticalPos", "DOVerticalPos");

            menu.AddSeparator("");

            AddMenuItem(menu, "Slider/DOValue", "DOValue");

            menu.AddSeparator("");

            AddMenuItem(menu, "Text/DOColor", "DOColor");
            AddMenuItem(menu, "Text/DOFade", "DOFade");
            AddMenuItem(menu, "Text/DOText", "DOText");

            menu.AddSeparator("Text/");

            AddMenuItem(menu, "Text/Blendable Tweens/DOBlendableColor", "DOBlendableColor");

            menu.AddSeparator("");

            AddMenuItem(menu, "VisualElement/DOMove", "DOMove");
            AddMenuItem(menu, "VisualElement/DOMoveX", "DOMoveX");
            AddMenuItem(menu, "VisualElement/DOMoveY", "DOMoveY");
            AddMenuItem(menu, "VisualElement/DOMoveZ", "DOMoveZ");
            AddMenuItem(menu, "VisualElement/DORotate", "DORotate");
            AddMenuItem(menu, "VisualElement/DOScale", "DOScale");
            AddMenuItem(menu, "VisualElement/DOPunch", "DOPunch");
            AddMenuItem(menu, "VisualElements/DOShake", "DOShake");

            Debug.Log(m_ComponentToAdd + " will be added to the " + target.name);
*/
            menu.ShowAsContext();
        }
        
        EditorGUILayout.EndHorizontal();
    }
}