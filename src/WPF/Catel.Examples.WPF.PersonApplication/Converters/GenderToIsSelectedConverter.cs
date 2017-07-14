// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenderToIsSelectedConverter.cs" company="Catel development team">
//   Copyright (c) 2008 - 2017 Catel development team. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Catel.Examples.PersonApplication.Converters
{
    using System;
    using System.Windows.Data;
    using Models;
    using MVVM.Converters;

    [ValueConversion(typeof(Gender), typeof(bool), ParameterType = typeof(Gender))]
    public class GenderToIsSelectedConverter : ValueConverterBase<Gender>
    {
        protected override object Convert(Gender value, Type targetType, object parameter)
        {
            // Parse parameter
            Gender genderRepresented = Gender.Unknown;
            if (parameter is Gender) genderRepresented = (Gender)parameter;
            else if (parameter is string) genderRepresented = (Gender)Enum.Parse(typeof(Gender), (string)parameter);

            // Cast
            Gender gender = (Gender)value;

            // Check values
            return (gender == genderRepresented);
        }

        protected override object ConvertBack(object value, Type targetType, object parameter)
        {
            // Parse parameter
            Gender genderRepresented = Gender.Unknown;
            if (parameter is Gender) genderRepresented = (Gender)parameter;
            else if (parameter is string) genderRepresented = (Gender)Enum.Parse(typeof(Gender), (string)parameter);

            // Check if the value is true or value
            bool isChecked = false;
            if (value is bool)
            {
                isChecked = (bool)value;
            }
            else if (value is bool?)
            {
                isChecked = ((bool?)value).HasValue ? ((bool?)value).Value : false;
            }

            // Return value
            return (isChecked) ? genderRepresented : Binding.DoNothing;
        }
    }
}