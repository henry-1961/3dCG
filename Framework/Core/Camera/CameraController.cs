﻿using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace Framework.Core.Camera
{
    /// <summary>
    /// 
    /// </summary>
    public class CameraController
    {
        /* ---------------------------------------------- Variáveis membro ---------------------------------------------- */

        private PerspectiveCamera camera;

        private GameWindow window;

        private bool firstMove = true;

        private Vector2 lastPos;

        /* ---------------------------------------------- Interface pública ---------------------------------------------- */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="window"></param>
        public CameraController(PerspectiveCamera camera, GameWindow window)
        {
            this.camera = camera;
            this.window = window;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="input"></param>
        /// <param name="mouse"></param>
        public void Update(FrameEventArgs e, KeyboardState input, MouseState mouse)
        {
            if (!window.IsFocused) // Check to see if the window is focused
            {
                return;
            }

            if (input.IsKeyDown(Keys.Escape))
            {
                window.Close();
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;

            if (input.IsKeyDown(Keys.W))
            {
                camera.Position += camera.Front * cameraSpeed * (float)e.Time; // Forward
            }

            if (input.IsKeyDown(Keys.S))
            {
                camera.Position -= camera.Front * cameraSpeed * (float)e.Time; // Backwards
            }
            if (input.IsKeyDown(Keys.A))
            {
                camera.Position -= camera.Right * cameraSpeed * (float)e.Time; // Left
            }
            if (input.IsKeyDown(Keys.D))
            {
                camera.Position += camera.Right * cameraSpeed * (float)e.Time; // Right
            }
            if (input.IsKeyDown(Keys.Space))
            {
                camera.Position += camera.Up * cameraSpeed * (float)e.Time; // Up
            }
            if (input.IsKeyDown(Keys.LeftShift))
            {
                camera.Position -= camera.Up * cameraSpeed * (float)e.Time; // Down
            }

            if (firstMove) // This bool variable is initially set to true.
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                firstMove = false;
            }
            else
            {
                // Calculate the offset of the mouse position
                var deltaX = mouse.X - lastPos.X;
                var deltaY = mouse.Y - lastPos.Y;
                lastPos = new Vector2(mouse.X, mouse.Y);

                // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
                camera.Yaw += deltaX * sensitivity;
                camera.Pitch -= deltaY * sensitivity; // Reversed since y-coordinates range from bottom to top
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void MouseUpdate(MouseWheelEventArgs e)
        {
            camera.Fov -= e.OffsetY;
        }
    }
}
