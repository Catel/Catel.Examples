// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentTracker.cs" company="Catel development team">
//   Copyright (c) 2008 - 2013 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.WPF.Prism.Services
{
    using Catel.Examples.WPF.Prism.Models;
    using Catel.Messaging;
    using Catel.Services;

    /// <summary>
    /// Keeps track of the department info.
    /// </summary>
    public class DepartmentTracker : ServiceBase, IDepartmentTracker
    {
        private readonly IMessageMediator _messageMediator;

        #region Fields
        private IDepartment _currentDepartment;
        #endregion

        public DepartmentTracker(IMessageMediator messageMediator)
        {
            Argument.IsNotNull(() => messageMediator);

            _messageMediator = messageMediator;
        }

        #region IDepartmentTracker Members
        public IDepartment CurrentDepartment
        {
            get { return _currentDepartment; }
            set
            {
                _currentDepartment = value;

                _messageMediator.SendMessage(CurrentDepartment, "CurrentDepartmentChanged");
            }
        }
        #endregion
    }
}