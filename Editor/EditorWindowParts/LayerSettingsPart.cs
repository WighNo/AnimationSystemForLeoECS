﻿using System;
using _.Ecs.AnimationSystem.Editor.Data;
using _.Ecs.AnimationSystem.Editor.Interfaces;
using CustomEditorTools;
using UnityEditor;
using UnityEngine;

namespace _.Ecs.AnimationSystem.Editor.EditorWindowParts
{
    public class LayerSettingsPart : WindowPartBase, ICustomEditorPart
    {
        private readonly EcsAnimationProperties _properties;

        public LayerSettingsPart(EcsAnimationProperties properties)
        {
            _properties = properties;
        }

        public void Render() => Part();

        protected override void Content()
        {
            PartTitle("Layer");

            EditorGUILayout.BeginVertical(GUIStyles.New(GUIStyle.none).Margin(16, 16, 0, 0));

            int layerIndex = _properties.AnimationData.GetLayerIndex();

            layerIndex = EditorGUILayout.IntField("Index:", layerIndex);

            if (layerIndex < 0)
                layerIndex = 0;

            _properties.AnimationData.SetLayerIndex(layerIndex);

            float layerWeight = _properties.AnimationData.GetLayerWeight();
            layerWeight = EditorGUILayout.Slider("Weight:", layerWeight, 0f, 1f);
            _properties.AnimationData.SetLayerWeight(layerWeight);
            
            EditorGUILayout.EndVertical();
        }
    }
}