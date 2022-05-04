using Autofac;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Application;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure.Implementation;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Module
{
    public class ParteRoleModule : Autofac.Module
    {
        private string _connectionString;
        public ParteRoleModule()
        {
            _connectionString = "data source=localhost;initial catalog=CitasMedicas;User ID=sa;Password=data;persist security info=False;packet size=4096";
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParteRoleRepository>().As<IParteRoleRepository>()
                .WithParameter("connectionString", _connectionString);
            builder.RegisterType<CreatePatientHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<FindPatientHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<GetDoctorsHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<GetDoctorHandler>().AsImplementedInterfaces().InstancePerDependency();
            base.Load(builder);
        }
    }
}
