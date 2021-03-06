﻿using System;

namespace FCK.Studio.Tools
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoMapper.Configuration.Configure();

            DevExpress.Skins.SkinManager.EnableFormSkins();

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new FormLogin());
            
        }
    }
}
