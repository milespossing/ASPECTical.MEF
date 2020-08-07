using MefContrib.Hosting.Interception;

namespace ASPECTical.MEF
{
    public class ProxyObjectInterceptor : IExportedValueInterceptor
    {
        private readonly IObjectSource _objectSource;

        public ProxyObjectInterceptor(IObjectSource objectSource)
        {
            _objectSource = objectSource;
        }

        public object Intercept(object value)
        {
            return _objectSource.CreateFromReal(value);
        }
    }
}