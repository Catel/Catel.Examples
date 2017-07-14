// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonDetailViewModel.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.MasterDetail.ViewModels
{
    using Data;
    using Models;
    using MVVM;

    public class PersonDetailViewModel : ViewModelBase
    {
        #region Constructors
        public PersonDetailViewModel(Person person)
        {
            Argument.IsNotNull(() => person);

            Person = person;

            Title = "Person";
        }
        #endregion

        #region Properties
        [Model]
        [Fody.Expose("Gender")]
        [Fody.Expose("FirstName")]
        [Fody.Expose("MiddleName")]
        [Fody.Expose("LastName")]
        private Person Person { get; set; }
        #endregion
    }
}