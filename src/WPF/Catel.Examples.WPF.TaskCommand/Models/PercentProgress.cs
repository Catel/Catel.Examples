// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PercentProgress.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.TaskCommand.Models
{
    using MVVM;

    public class PercentProgress : ITaskProgressReport
    {
        #region Constructors
        public PercentProgress(int percent, string status = null)
        {
            Percent = percent;
            Status = status;
        }
        #endregion

        #region Properties
        public int Percent { get; private set; }
        public string Status { get; private set; }
        #endregion
    }
}