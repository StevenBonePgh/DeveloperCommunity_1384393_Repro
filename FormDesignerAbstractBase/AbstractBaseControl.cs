#define VS2017_ABSTRACT_BASE_METHOD
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FormDesignerAbstractBase
{
#if VS2017_ABSTRACT_BASE_METHOD
    // Because this is an abstract base class, derived types can't open in the Visual Studio Designer. The error given is:
    // "The designer must create an instance of type 'FormDesignerAbstractBase.AbstractBaseControl' but it cannot because 
    // the type is declared as abstract." Apply this attribute to allow derived types to work in designer. Works in 15.9.34
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AbstractBaseControl, AbstractBaseControlHidden2>))]
#endif
    [System.ComponentModel.DesignerCategory("Code")] // so VS does not try to open this file in the Designer 
    public abstract class AbstractBaseControl : UserControl
    {

#if VS2017_ABSTRACT_BASE_METHOD
        private class AbstractBaseControlHidden2 : AbstractBaseControlHidden
        {
        }

        private class AbstractBaseControlHidden : AbstractBaseControl
        {
            public override bool SomeAbstractMethod()
            {
                throw new NotImplementedException();
            }
        }
#endif
        public abstract bool SomeAbstractMethod();
    }
}
