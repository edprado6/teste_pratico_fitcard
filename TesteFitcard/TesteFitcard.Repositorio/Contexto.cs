using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TesteFitcard.Dominio.Entidades;


namespace TesteFitcard.Repositorio
{
    /// <summary>
    /// Classe que representa o contexto da aplicação.
    /// </summary>
    public class Contexto : DbContext
    {
        //public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        /// <summary>
        /// Método construtor vazio.
        /// </summary>
        public Contexto()
        {
        }

        /// <summary>
        /// Método construtor com parâmetros.
        /// </summary>
        /// <param name="options"></param>
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        /// <summary>
        /// Obtenha as configurações do aplicativo.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseMySQL(connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Sobreescreve o método SaveChanges.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            SetaDataCadastro();
            SetaDataAtualizacao();

            return base.SaveChanges();
        }

        /// <summary>
        /// Verifica se existe a propriedade DataCadastro, caso exista e se trate de uma inserção de registro o campo recebe a data e horários atuais.
        /// </summary>
        private void SetaDataCadastro()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
        }

        /// <summary>
        /// Verifica se existe a propriedade DataAtualizacao, caso ela exista e se trate de uma atualização o campo recebe a data e horários atuais.
        /// </summary>
        private void SetaDataAtualizacao()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAtualizacao") != null))
            {
                if ((entry.State == EntityState.Modified))
                {
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }
        }
    }
}
