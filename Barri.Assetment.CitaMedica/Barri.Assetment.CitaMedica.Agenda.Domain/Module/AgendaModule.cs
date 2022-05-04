using Autofac;
using Barri.Assetment.CitaMedica.Agenda.Domain.Application;
using Barri.Assetment.CitaMedica.Agenda.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.Agenda.Domain.Infraestructure.Implementation;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Module
{
    public class AgendaModule : Autofac.Module
    {
        private string _connectionString;
        public AgendaModule()
        {
            _connectionString = "data source=localhost;initial catalog=CitasMedicas;User ID=sa;Password=data;persist security info=False;packet size=4096";
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AgendaRepository>().As<IAgendaRepository>()
                .WithParameter("connectionString", _connectionString);
            builder.RegisterType<GetHorariosHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<FindAgendaHandler>().AsImplementedInterfaces().InstancePerDependency();
            builder.RegisterType<AddAgendaHandler>().AsImplementedInterfaces().InstancePerDependency();
            base.Load(builder);
        }
    }
}
