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
using System;
using System.Collections.Generic;
using System.Text;
using Duplicati.Library.Interface;

namespace Duplicati.Library.DynamicLoader
{
    public static class WebLoader
    {
        /// <summary>
        /// Implementation overrides specific to encryption
        /// </summary>
        private class WebLoaderSub : DynamicLoader<IWebModule>
        {
            /// <summary>
            /// Returns the filename extension, which is also the key
            /// </summary>
            /// <param name="item">The item to load the key for</param>
            /// <returns>The file extension used by the module</returns>
            protected override string GetInterfaceKey(IWebModule item)
            {
                return item.Key;
            }

            /// <summary>
            /// Returns the subfolders searched for encryption modules
            /// </summary>
            protected override string[] Subfolders
            {
                get { return new string[] { "webmodules" }; }
            }
        }

        #region Public static API

        /// <summary>
        /// Gets a list of loaded settings controls, the instances can be used to extract interface information, not used to interact with the module.
        /// </summary>
        public static IWebModule[] Modules { get { return new WebLoaderSub().Interfaces; } }

        /// <summary>
        /// Gets a list of keys supported
        /// </summary>
        public static string[] Keys { get { return new WebLoaderSub().Keys; } }

        #endregion
    }
}

