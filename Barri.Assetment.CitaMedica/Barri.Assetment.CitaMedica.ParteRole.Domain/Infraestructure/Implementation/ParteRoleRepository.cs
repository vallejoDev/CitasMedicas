using Barri.Assetment.CitaMedica.ParteRole.Domain.Model;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure.Implementation
{
    public class ParteRoleRepository : IParteRoleRepository
    {
        private readonly string _connectionString;
        public ParteRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        private IDbConnection Connection => new SqlConnection(_connectionString);
        public void Dispose()
        {
            Connection.Close();
        }
        public async Task<Person> Find(string mail)
        {
            using (Connection)
            {
                var query = "SELECT PR.IdParteRole, PR.IdTipoParteRole, P.Nombre, P.ApellidoPaterno, P.ApellidoMaterno, P.Correo[Mail] FROM dbo.Persona P INNER JOIN dbo.Parte P2 ON P2.IdParte = P.IdParte INNER JOIN dbo.ParteRole PR ON PR.IdParte = P2.IdParte WHERE P.Correo = @Mail;";
                var person = await Connection.QueryFirstAsync<Person>(query, new { Mail = mail });
                return await Task.FromResult(person);
            }
        }

        public async Task<Person> Get(int idParteRole)
        {
            using (Connection)
            {
                var query = "SELECT PR.IdParteRole, PR.IdTipoParteRole, P.Nombre, P.ApellidoPaterno, P.ApellidoMaterno, P.Correo[Mail] FROM dbo.Persona P INNER JOIN dbo.Parte P2 ON P2.IdParte = P.IdParte INNER JOIN dbo.ParteRole PR ON PR.IdParte = P2.IdParte WHERE PR.IdParteRole = @IdParteRole;";
                var person = await Connection.QueryFirstAsync<Person>(query, new { IdParteRole = idParteRole});
                return await Task.FromResult(person);
            }
        }

        public async Task<IEnumerable<Person>> GetAll(int idTipoParteRole)
        {
            using (Connection)
            {
                var query = "SELECT PR.IdParteRole, PR.IdTipoParteRole, P.Nombre, P.ApellidoPaterno, P.ApellidoMaterno, P.Correo[Mail] FROM dbo.Persona P INNER JOIN dbo.Parte P2 ON P2.IdParte = P.IdParte INNER JOIN dbo.ParteRole PR ON PR.IdParte = P2.IdParte WHERE PR.IdTipoParteRole = @IdTipoParteRole";
                var persons = await Connection.QueryAsync<Person>(query, new { IdtipoParteRole = idTipoParteRole });
                return await Task.FromResult(persons);
            }
        }

        public async Task<int> Insert(Person person)
        {
            int idResult = 0;
            using (Connection)
            {
                idResult = await Connection.QueryFirstAsync<int>("CreateParteRole", new
                {
                    @IdTipoParteRole = person.IdTipoParteRole,
                    @Nombre = person.Nombre,
                    @ApellidoPaterno = person.ApellidoPaterno,
                    @ApellidoMaterno = person.ApellidoMaterno,
                    @Correo = person.Mail
                }, commandType: CommandType.StoredProcedure);
            }

            return await Task.FromResult(idResult);
        }
    }
}
