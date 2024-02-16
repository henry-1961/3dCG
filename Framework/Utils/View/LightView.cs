﻿using ImGuiNET;

using Framework.Core.Light;

namespace Framework.Utils.View
{
    public class LightView
    {
        private Light light;
        private AmbientLight ambientLight;

        public LightView(Light light, AmbientLight ambientLight)
        {
            this.light = light;
            this.ambientLight = ambientLight;
        }

        public void DrawControl()
        {
            ImGui.Begin("Light");

            if(ImGui.BeginTabBar("Settings"))
            {
                if (ImGui.BeginTabItem("Diffuse"))
                {
                    ImGui.DragFloat3("Position", ref light.position, 0.001f);
                    ImGui.DragFloat3("Direction", ref light.direction, 0.001f);
                    ImGui.ColorPicker3("Color", ref light.color, ImGuiColorEditFlags.PickerHueWheel);
                    ImGui.DragFloat("Intensity", ref light.intensity, 0.001f, 0.0f, 2.0f);

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("Ambient"))
                {
                    ImGui.ColorPicker3("Color", ref ambientLight.color, ImGuiColorEditFlags.PickerHueWheel);
                    ImGui.DragFloat("Intensity", ref ambientLight.intensity, 0.001f, 0.0f, 2.0f);

                    ImGui.EndTabItem();
                }

                if (ImGui.BeginTabItem("Shadow"))
                {
                    ImGui.Checkbox("Cast Shadow", ref light.castShadow);

                    ImGui.EndTabItem();
                }

                ImGui.EndTabBar();
            }

            ImGui.End();
        }

        public void DrawGuismo()
        {
            // TODO: Draw a textured point to represent the light bulb and it's target
        }
    }
}
