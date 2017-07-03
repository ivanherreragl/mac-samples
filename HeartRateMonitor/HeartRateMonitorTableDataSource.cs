//
// HeartRateMonitorTableDataSource.cs
//
// Author:
//   Aaron Bockover <abock@xamarin.com>
//
// Copyright 2013 Xamarin, Inc.
// Copyright 2017 Microsoft.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;

using Foundation;
using AppKit;
using CoreBluetooth;

namespace Xamarin.HeartMonitor
{
	public sealed class HeartRateMonitorTableDataSource : NSTableViewDataSource
	{
		readonly List<CBPeripheral> heartRateMonitors = new List<CBPeripheral> ();

		public void Add (CBPeripheral peripheral)
		{
			if (!heartRateMonitors.Contains (peripheral))
				heartRateMonitors.Add (peripheral);
		}

		public void Remove (CBPeripheral peripheral)
			=> heartRateMonitors.Remove (peripheral);

		public override NSObject GetObjectValue (NSTableView tableView, NSTableColumn tableColumn, nint row)
			=> new NSString (heartRateMonitors [(int)row]?.Name ?? "Unknown Peripheral");

		public override nint GetRowCount (NSTableView tableView)
			=> heartRateMonitors.Count;
		
		public CBPeripheral this [int row] {
			get {
				if (row < 0 || row >= heartRateMonitors.Count)
					return null;

				return heartRateMonitors [row];
			}
		}
	}
}