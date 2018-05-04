// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITabService.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.ViewModelLifetime.Services
{
    public interface ITabService
    {
        #region Methods
        void AddTab(bool closeViewModelOnUnload);
        #endregion
    }
}