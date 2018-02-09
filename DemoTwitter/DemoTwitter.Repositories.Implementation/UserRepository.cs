using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Linq;
using Dapper;
using DemoTwitter.DomainModel;

namespace DemoTwitter.Repositories.Implementation
{
    [Export(typeof(IUserRepository))]
    public class UserRepository : IUserRepository
    {
        private readonly IConnectionProvider connectionProvider;


        [ImportingConstructor]
        public UserRepository(IConnectionProvider connectionProvider)
        {
            this.connectionProvider = connectionProvider;
        }

        public User GetUserByEmail(string emailAddress)
        {
            using (var dbConnection = connectionProvider.CreateMainDatabaseConnection())
            {
                return dbConnection.Query<User>("USP_GET_USER_BY_EMAIL", new { email = emailAddress }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public User GetUserById(int id)
        {
            using (var dbConnection = connectionProvider.CreateMainDatabaseConnection())
            {
                return dbConnection.Query<User>("USP_GET_USER_BY_ID", new { userId = id }, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
        }

        public IEnumerable<User> GetUsers()
        {
            using (var dbConnection = connectionProvider.CreateMainDatabaseConnection())
            {
                return dbConnection.Query<User>("USP_GET_ALL_USERS", CommandType.StoredProcedure);
            }
        }
    }
}
