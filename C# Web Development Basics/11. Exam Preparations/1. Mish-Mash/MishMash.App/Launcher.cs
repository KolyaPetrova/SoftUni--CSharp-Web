﻿using SIS.Framework;

namespace MishMash.App
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            WebHost.Start(new StartUp());
        }
    }
}
