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

namespace Duplicati.Library.Main.Operation.Common
{
    /// <summary>
    /// The types of events being sent
    /// </summary>
    public enum EventType
    {
        FileStarted,
        FileProgressUpdate,
        FileClosed,
        FileSkipped
    }

    /// <summary>
    /// Description of a particular event
    /// </summary>
    public struct ProgressEvent
    {
        public EventType Type { get; set; }
        public string Filepath { get; set; }
        public long Length { get; set; }
    }
}

