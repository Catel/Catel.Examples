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

        public const string Test1 = "Test1";
        public static readonly InputGesture Test1InputGesture = new InputGesture(Key.A, ModifierKeys.Control|ModifierKeys.Shift);
        public const string Test2 = "Test2";
        public static readonly InputGesture Test2InputGesture = new InputGesture(Key.A, ModifierKeys.Control|ModifierKeys.Alt);
    }
}
