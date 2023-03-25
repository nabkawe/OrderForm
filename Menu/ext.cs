using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace OrderForm
{
    public class BoolToVisibilityConverter : BoolToValueConverter<Visibility>
    {
        #region Constructors and Destructors

        public BoolToVisibilityConverter()
        {
            this.TrueValue = Visibility.Visible;
            this.FalseValue = Visibility.Collapsed;
        }

        #endregion
    }

    /// <summary>
    /// Use as the base class for BoolToXXX style converters
    /// </summary>
    /// <typeparam name="T"></typeparam>    
    public abstract class BoolToValueConverter<T> : MarkupExtension, IValueConverter
    {
        #region Constructors and Destructors

        protected BoolToValueConverter()
        {
            this.TrueValue = default(T);
            this.FalseValue = default(T);
        }

        #endregion

        #region Public Properties

        public T FalseValue { get; set; }

        public T TrueValue { get; set; }

        #endregion

        #region Public Methods and Operators

        public object Convert(object value, Type targetType,
                              object parameter, CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? this.TrueValue : this.FalseValue;
        }

        // Override if necessary
        public virtual object ConvertBack(object value, Type targetType,
                                          object parameter, CultureInfo culture)
        {
            return value.Equals(this.TrueValue);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        #endregion
    }
 

    //public class BooleanToStringConverter : IValueConverter
    //{
    //    public string TrueValue { get; set; }
    //    public string FalseValue { get; set; }

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value == null) return FalseValue;
    //        return (bool)value ? TrueValue : FalseValue;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return value != null && value.ToString() == TrueValue;
    //    }
    //}
    //    public class BooleanToValueConverter : IValueConverter
    //{
    //    public string TrueValue { get; set; }
    //    public string FalseValue { get; set; }

    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if (value == null) return FalseValue;
    //        return (bool)value ? TrueValue : FalseValue;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return value != null && value.ToString() == TrueValue;
    //    }
    //}


    //public class BoolToVisibilityConverter : BoolToVisibility3Converter<Visibility>
    //{
    //    #region Constructors and Destructors

    //    public BoolToVisibilityConverter()
    //    {
    //        this.TrueValue = Visibility.Visible;
    //        this.FalseValue = Visibility.Collapsed;
    //    }

    //    #endregion
    //}

    ///// <summary>
    ///// Use as the base class for BoolToXXX style converters
    ///// </summary>
    ///// <typeparam name="T"></typeparam>    
    //public abstract class BoolToVisibility3Converter<T> : MarkupExtension, IValueConverter
    //{
    //    #region Constructors and Destructors

    //    public BoolToVisibility3Converter()
    //    {
    //        this.TrueValue = default(T);
    //        this.FalseValue = default(T);
    //    }

    //    #endregion

    //    #region Public Properties

    //    public T FalseValue { get; set; }

    //    public T TrueValue { get; set; }

    //    #endregion

    //    #region Public Methods and Operators

    //    public object Convert(object value, Type targetType,
    //                          object parameter, CultureInfo culture)
    //    {
    //        return System.Convert.ToBoolean(value) ? this.TrueValue : this.FalseValue;
    //    }

    //    // Override if necessary
    //    public virtual object ConvertBack(object value, Type targetType,
    //                                      object parameter, CultureInfo culture)
    //    {
    //        return value.Equals(this.TrueValue);
    //    }

    //    public override object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        return this;
    //    }

    //    #endregion
    //}
}
