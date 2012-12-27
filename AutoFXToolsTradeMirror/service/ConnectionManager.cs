﻿using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using TraceSourceLogger;

namespace Microsoft.Samples.NetTcp
{
    public class ConnectionManager
    {
        private static readonly Type OType = typeof(TradeMirrorService);

        //private const string ConnectionString = "SERVER=localhost;DATABASE=autofxtest;UID=root;PASSWORD=rootpassword";
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["autofxtest"].ConnectionString;

        private readonly MySqlConnection _connection;

        /// <summary>
        /// Constructor
        /// </summary>
        public ConnectionManager()
        {
            this._connection = new MySqlConnection {ConnectionString = _connectionString};
        }
        
        /// <summary>
        /// Open a connection to DB
        /// </summary>
        /// <returns></returns>
        public MySqlConnection Connect()
        {
            try
            {
                this._connection.Open();
                Logger.Debug("Connected to database", OType.FullName, "Connect");
                return this._connection;
            }

            catch (Exception exception)
            {
                Logger.Error("Exception while opening connection to Databse. Exception = " + exception, OType.FullName, "Connect");
                return null;
            }
        }

        /// <summary>
        /// Close connection to DB
        /// </summary>
        public void Disconnect()
        {
            try
            {
                this._connection.Close();
                Logger.Debug("Dis-Connected from database", OType.FullName, "Disconnect");
            }
            catch (Exception exception)
            {
                Logger.Error("Exception while closing connection to Databse. Exception = " + exception, OType.FullName, "Disconnect");
            }
        }
    }
}