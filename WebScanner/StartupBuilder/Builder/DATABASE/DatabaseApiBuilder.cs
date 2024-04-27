﻿using Microsoft.EntityFrameworkCore;
using WebScrapper.INFRA;

namespace WebScanner.StartupBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class DatabaseApiBuilder
    {
        WebApplicationBuilder builder;

        public WebApplicationBuilder Builder { get => builder; set => builder = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builders"></param>
        public DatabaseApiBuilder(WebApplicationBuilder builders)
        {
            builder = builders;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuildDbContext()
        {
            string value = Environment
            .GetEnvironmentVariable("ENVIRONMENT");
            if (value == null) { throw new Exception("NullValue"); }
            else
            {
            }

            //Configuration de la base de donn�es en fonction de l'environnement
            if (value == "stage" || builder.Environment.IsStaging())
            {
                #region ENV

                string DB_SERVER_STAGE = Environment
                    .GetEnvironmentVariable("DB_SERVER_STAGE");
                if (DB_SERVER_STAGE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string DB_PORT_STAGE = Environment
                    .GetEnvironmentVariable("DB_PORT_STAGE");
                if (DB_PORT_STAGE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string DB_NAME_STAGE = Environment
                    .GetEnvironmentVariable("DB_NAME_STAGE");
                if (DB_NAME_STAGE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string DB_USER_STAGE = Environment
                    .GetEnvironmentVariable("DB_USER_STAGE");
                if (DB_USER_STAGE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string DB_PASSWORD_STAGE = Environment
                    .GetEnvironmentVariable("DB_PASSWORD_STAGE");
                if (DB_PASSWORD_STAGE == null) { throw new Exception("NullValue"); }
                else
                {
                }
                string DB_TRUST_CERTIFICATE_SERVER_STAGE = Environment
                    .GetEnvironmentVariable("DB_TRUST_CERTIFICATE_SERVER_STAGE");
                if (DB_TRUST_CERTIFICATE_SERVER_STAGE == null) { throw new Exception("NullValue"); }
                else
                {
                }

                #endregion

                builder.Services
                    .AddDbContext<ApiDbContext>(options =>
                        options
                        .UseSqlServer(
                            $"Server={DB_SERVER_STAGE},{DB_PORT_STAGE};" +
                            $"Database={DB_NAME_STAGE};" +
                            $"User id={DB_USER_STAGE};" +
                            $"Pwd={DB_PASSWORD_STAGE};" +
                            $"TrustServerCertificate={DB_TRUST_CERTIFICATE_SERVER_STAGE}"
                         )
                );
            }
            else if (value == "prod" || builder.Environment.IsProduction())
            {
                #region ENV

                string DB_SERVER_PROD = Environment
                    .GetEnvironmentVariable("DB_SERVER_PROD");
                string DB_PORT_PORT = Environment
                    .GetEnvironmentVariable("DB_PORT_PORT");
                string DB_NAME_PROD = Environment
                    .GetEnvironmentVariable("DB_NAME_PROD");
                string DB_USER_PROD = Environment
                    .GetEnvironmentVariable("DB_USER_PROD");
                string DB_PASSWORD_PROD = Environment
                    .GetEnvironmentVariable("DB_PASSWORD_PROD");
                string DB_TRUST_CERTIFICATE_SERVER_PROD = Environment
                    .GetEnvironmentVariable("DB_TRUST_CERTIFICATE_SERVER_PROD");

                #endregion

                builder.Services
                    .AddDbContext<ApiDbContext>(options =>
                        options
                        .UseSqlServer(
                            $"Server={DB_SERVER_PROD},{DB_PORT_PORT};" +
                            $"Database={DB_NAME_PROD};" +
                            $"User id={DB_USER_PROD};" +
                            $"Pwd={DB_PASSWORD_PROD};" +
                            $"TrustServerCertificate={DB_TRUST_CERTIFICATE_SERVER_PROD}"
                            )
                        );
            }
            else
            {
                #region ENV

                string DB_NAME_INMEMORY = Environment
                    .GetEnvironmentVariable("DB_NAME_INMEMORY");
                if (DB_NAME_INMEMORY == null) { throw new Exception("NullValue"); }
                else
                {
                }
                #endregion

                builder.Services
                    .AddDbContext<ApiDbContext>(options =>
                        options
                        .UseInMemoryDatabase(DB_NAME_INMEMORY));
            }
        }
    }
}