// This file was generated by the Gtk# code generator.
// Any changes made will be lost if regenerated.

namespace Nautilus {

	using System;

	public delegate void ProgressChangedHandler(object o, ProgressChangedArgs args);

	public class ProgressChangedArgs : GLib.SignalArgs {
		public double Fraction{
			get {
				return (double) Args[0];
			}
		}

	}
}
