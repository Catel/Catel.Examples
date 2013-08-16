// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WPF.Prism.ViewModels
{
    using Catel.Messaging;

    /// <summary>
    /// View model base class specially made for the prism example with additional default properties.
    /// </summary>
    public abstract class ViewModelBase : MVVM.ViewModelBase
    {
        #region Constructors
        protected ViewModelBase(IMessageMediator messageMediator)
        {
            Argument.IsNotNull(() => messageMediator);

            MessageMediator = messageMediator;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the message mediator.
        /// </summary>
        public IMessageMediator MessageMediator { get; private set; }
        #endregion
    }
}