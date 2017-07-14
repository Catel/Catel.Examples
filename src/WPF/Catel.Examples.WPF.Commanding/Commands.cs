// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Commands.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.Commanding
{
    using System.Windows.Input;
    using InputGesture = Windows.Input.InputGesture;

    public static class Commands
    {
        public const string Refresh = "Refresh";

        public const string GlobalAction = "GlobalAction";
        public static readonly InputGesture GlobalActionInputGesture = new InputGesture(Key.G, ModifierKeys.Control);
    }
}