using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Infra.Dados.EntityConfigs
{
    public  class UsuarioAmigoEntityConfig : IEntityTypeConfiguration<UsuarioAmigo>
    {
        public void Configure(EntityTypeBuilder<UsuarioAmigo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
            builder.HasMany(x => x.Amigos);
        }
    }
}
