﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
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

        public User GetUserByEmail(string email)
        {
            var dbConnection = connectionProvider.CreateMainDatabaseConnection();
            dbConnection.Open();
            string SqlString = "SELECT [USERNAME], [EMAIL], [FIRSTNAME], [LASTNAME], [AVATAR] FROM [Users] WHERE";
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            using (var dbConnexion = connectionProvider.CreateMainDatabaseConnection())
            {
                return dbConnexion.Query<User>("SELECT [USERNAME], [EMAIL], [FIRSTNAME], [LASTNAME], [AVATAR] FROM [Users]");
            }
        }
    }
}
