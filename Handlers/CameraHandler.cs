﻿using GameSpace.Abstracts;
using GameSpace.Camera2D;
using System.Diagnostics;

namespace GameSpace.EntityManaging
{
    public class CameraHandler : AbstractHandler
    {
        private static readonly CameraHandler instance = new CameraHandler();

        public static CameraHandler GetInstance()
        {
            return instance;
        }

        private CameraHandler()
        {

        }

        public void LoadCamera(Camera camera)
        {
            cameraCopy = camera;
        }

        public void DebugCameraFindLimits()
        {
            //Debug.WriteLine("Camera Limits:" + cameraCopy. + "   " + cameraCopy.Limits.Value.Y);
        }
    }
}
