using Barri.Assetment.CitaMedica.Agenda.Domain.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Infraestructure.Implementation
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly string _connectionString;
        public AgendaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);
        public void Dispose()
        {
            Connection.Close();
        }
        public async Task<IEnumerable<AgendaInfo>> Find(int idParteRoleDoctor, DateTime fecha)
        {
            using (Connection)
            {
                var query = 
                    "SELECT " +
                    "AM.IdAgenda, AM.IdHorario, AM.IdParteRoleDoctor, AM.IdParteRolePaciente, AM.Fecha, P.Nombre, P.ApellidoPaterno, P.ApellidoMaterno, P.Correo [Mail] " +
                    "FROM dbo.AgendaMedica AM " +
                    "INNER JOIN dbo.ParteRole PR ON PR.IdParteRole = AM.IdParteRolePaciente " +
                    "INNER JOIN dbo.Persona P ON P.IdParte = PR.IdParte " +
                    "WHERE AM.IdParteRoleDoctor = @IdParteRoleDoctor AND AM.Fecha = @Fecha";
                var persons = await Connection.QueryAsync<AgendaInfo>(query, new { IdParteRoleDoctor = idParteRoleDoctor, Fecha = fecha });
                return await Task.FromResult(persons);
            }
        }

        public async Task<IEnumerable<Horario>> GetAllHorarios()
        {
            using (Connection)
            {
                try
                {
                    var result = await Connection.GetAllAsync<Horario>();
                    return await Task.FromResult(result);
                }
                catch (Exception e)
                {
                }
            }
            return await Task.FromResult((IEnumerable<Horario>)null);
        }

        public async Task Insert(AgendaItem agenda)
        {
            using (Connection)
            {
                var queryInsert = "INSERT INTO dbo.AgendaMedica(IdParteRoleDoctor, IdParteRolePaciente, IdHorario, Fecha) " +
                    "VALUES(@IdParteRoleDoctor, @IdParteRolePaciente, @IdHorario, @Fecha)";
                await Connection.ExecuteAsync(queryInsert, new
                {
                    agenda.IdParteRoleDoctor,
                    agenda.IdParteRolePaciente,
                    agenda.IdHorario,
                    agenda.Fecha
                });
            }
        }
    }
}
