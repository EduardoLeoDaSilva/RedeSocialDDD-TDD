using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RedeSocial_DDD_TDD.Dominio.Entidades;
using RedeSocial_DDD_TDD.Infra.Dados.EntityConfigs;

namespace RedeSocial_DDD_TDD.Infra.Dados.Contexto
{
    public class AplicacaoContexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Postagem> Postagem { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<UsuarioAmigo> UsuarioAmigo { get; set; }
        public DbSet<LikePostagem> LikePostagem { get; set; }


        public AplicacaoContexto(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new LikeEntityConfig());
            modelBuilder.ApplyConfiguration(new LikePostagemEntityConfig());
            modelBuilder.ApplyConfiguration(new PerfilEntityConfig());
            modelBuilder.ApplyConfiguration(new PostagemEntityConfig());
            modelBuilder.ApplyConfiguration(new UsuarioEntityConfig());
            modelBuilder.ApplyConfiguration(new UsuarioAmigoEntityConfig());
            modelBuilder.ApplyConfiguration(new ComentarioEntityConfig());
            modelBuilder.ApplyConfiguration(new FotoEntityConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
