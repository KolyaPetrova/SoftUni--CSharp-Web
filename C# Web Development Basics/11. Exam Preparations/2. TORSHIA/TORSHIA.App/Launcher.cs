﻿using SIS.Framework;

namespace TORSHIA.App
{
    public class Launcher
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
