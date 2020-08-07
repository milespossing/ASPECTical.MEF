using ASPECTical.Injection;
using MefContrib.Hosting.Interception;

namespace ASPECTical.MEF
{
    public class CreationInterceptor : IExportedValueInterceptor
    {
        private readonly IObjectCreationInterceptor _interceptor;

        public CreationInterceptor(IObjectCreationInterceptor interceptor)
        {
            _interceptor = interceptor;
        }

        public object Intercept(object value)
        {
            return _interceptor.InterceptCreatedObject(value);
        }
    }
}