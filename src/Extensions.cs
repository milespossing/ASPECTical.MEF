using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.IO;
using MefContrib.Hosting.Interception;
using MefContrib.Hosting.Interception.Configuration;

namespace ASPECTical.MEF
{
    public static class Extensions
    {
        public static IMefBuilder UseMef(this IContainerBuilder builder, ComposablePartCatalog catalog)
        {
            return new MefBuilder(builder, catalog);
        }
    }

    public interface IMefBuilder
    {
        CompositionContainer Container { get; }
    }

    public class MefBuilder : IMefBuilder
    {
        public MefBuilder(IContainerBuilder builder, ComposablePartCatalog catalog)
        {
            var cfg = new InterceptionConfiguration();
            builder.ObjectSource.CreationInterceptors.ForEach(i => cfg.AddInterceptor(new CreationInterceptor(i)));
            cfg.AddInterceptor(new ProxyObjectInterceptor(builder.ObjectSource));
            var interceptingCatalog = new InterceptingCatalog(catalog, cfg);
            Container = new CompositionContainer(interceptingCatalog);
        }

        public CompositionContainer Container { get; set; }
    }
}