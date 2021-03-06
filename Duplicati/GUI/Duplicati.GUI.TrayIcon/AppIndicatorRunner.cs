//  Copyright (C) 2015, The Duplicati Team
//  http://www.duplicati.com, info@duplicati.com
//  
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
// 
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
#if __WindowsGTK__ || ENABLE_GTK
using System;
using AppIndicator;
using Gtk;
using System.Collections.Generic;

using Duplicati.Library.Common.IO;
using Duplicati.Library.Utility;
using Duplicati.Server.Serialization;


namespace Duplicati.GUI.TrayIcon
{
    public class AppIndicatorRunner : GtkRunner
    {
        protected ApplicationIndicator m_appIndicator;
        private string m_themeFolder;
                
        protected override void CreateTrayInstance()
        {
            m_themeFolder = SystemIO.IO_OS.PathCombine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "SVGIcons");
            m_themeFolder = SystemIO.IO_OS.PathCombine(m_themeFolder, "dark");
            
            m_appIndicator = new ApplicationIndicator("duplicati", "normal", Category.ApplicationStatus, m_themeFolder);
        }
        
        protected override void Run(string[] args)
        {
            m_appIndicator.Menu.ShowAll(); 
            m_appIndicator.Status = Status.Active;
            Gtk.Application.Run();
        }
        
        protected override void SetMenu (IEnumerable<IMenuItem> items)
        {
            base.SetMenu(items);
            m_appIndicator.Menu = m_popupMenu;
        }
        
        protected override void SetIcon(TrayIcons icon)
        {
            m_appIndicator.IconName = GetTrayIconFilename(icon);

            switch (icon)
            {
                case TrayIcons.Paused:
                    m_appIndicator.IconDesc = "Paused";
                    break;
                case TrayIcons.Running:
                    m_appIndicator.IconDesc = "Running";
                    break;
                case TrayIcons.IdleWarning:
                    m_appIndicator.IconDesc = "Warning";
                    break;
                case TrayIcons.IdleError:
                    m_appIndicator.IconDesc = "Error";
                    break;
                case TrayIcons.RunningError:
                    m_appIndicator.IconDesc = "Running";
                    break;
                case TrayIcons.PausedError:
                    m_appIndicator.IconDesc = "Paused";
                    break;
                case TrayIcons.Idle:
                default:
                    m_appIndicator.IconDesc = "Ready";
                    break;
            }
        }
    }
}
#endif
