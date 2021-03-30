using System;
using System.ComponentModel;

namespace FormDesignerAbstractBase
{
    /// <summary>   For use with a <see cref="TypeDescriptionProviderAttribute"/> to enable designer support on an abstract class that derives from 
    ///             <c>System.Windows.Forms.Form</c> or <c>System.Windows.Forms.UserControl</c>.
    ///             This prevents errors such as "The designer must create an instance of type Foo but it cannot because the type is declared as abstract."
    ///             when the inheritance looks like:
    ///             abstract class AbstractBaseFoo : UserControl { }
    ///             class Foo : AbstractBaseFoo { } 
    ///             To fix this error, apply the following attribute to 'AbstractBaseFoo':
    ///             [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider&lt;AbstractBaseFoo, UserControl&gt;))]
    /// </summary>
    /// <typeparam name="TAbstract">    Type of the abstract class that inherits from Form or UserControl. </typeparam>
    /// <typeparam name="TBase">        The concrete class that the abstract class inherits from, which will be UserControl or Form. </typeparam>
    /// <seealso cref="T:System.ComponentModel.TypeDescriptionProvider"/>
    /// <seealso href="http://stackoverflow.com/questions/1620847/how-can-i-get-visual-studio-2008-windows-forms-designer-to-render-a-form-that-im"/>
    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        /// <summary>   Constructor. </summary>
        public AbstractControlDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        /// <summary>   Performs normal reflection against the given object with the given type. </summary>
        /// <param name="objectType">   The type of object for which to retrieve the
        ///                             <see cref="T:System.Reflection.IReflect" />. </param>
        /// <param name="instance">     An instance of the type. Can be null. </param>
        /// <returns>   The type of reflection for this <paramref name="objectType" />. </returns>
        /// <seealso cref="M:System.ComponentModel.TypeDescriptionProvider.GetReflectionType(Type,object)"/>
        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType.FullName == typeof(TAbstract).FullName)
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        /// <summary>   Creates an object that can substitute for another data type. </summary>
        /// <param name="provider">     An optional service provider. </param>
        /// <param name="objectType">   The type of object to create. This parameter is never null. </param>
        /// <param name="argTypes">     An optional array of types that represent the parameter types to
        ///                             be passed to the object's constructor. This array can be null or
        ///                             of zero length. </param>
        /// <param name="args">         An optional array of parameter values to pass to the object's
        ///                             constructor. </param>
        /// <returns>   The substitute <see cref="T:System.Object" />. </returns>
        /// <seealso cref="M:System.ComponentModel.TypeDescriptionProvider.CreateInstance(IServiceProvider,Type,Type[],object[])"/>
        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType.FullName == typeof(TAbstract).FullName)
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}
