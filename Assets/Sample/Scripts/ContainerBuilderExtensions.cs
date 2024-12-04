using Scellecs.Morpeh;
using VContainer;

namespace Sample
{
    public static class ContainerBuilderExtensions
    {
        public static RegistrationBuilder RegisterSystem<T>(this IContainerBuilder builder) where T : ISystem
            => builder.Register<ISystem, T>(Lifetime.Singleton);

        public static RegistrationBuilder RegisterFixedSystem<T>(this IContainerBuilder builder) where T : IFixedSystem
            => builder.Register<IFixedSystem, T>(Lifetime.Singleton);

        public static RegistrationBuilder RegisterCleanupSystem<T>(this IContainerBuilder builder) where T : ICleanupSystem
            => builder.Register<ICleanupSystem, T>(Lifetime.Singleton);
    }
}