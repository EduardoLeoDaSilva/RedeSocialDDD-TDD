using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Infra.Dados.EntityConfigs
{
    public class ComentarioEntityConfig: IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Comentarios");
            builder.Property(x => x.Texto).IsRequired(true);
            builder.Property(x => x.Texto).HasColumnType("varchar(100)");
            builder.HasOne(x => x.Usuario);
            builder.HasOne(x => x.Postagem).WithMany(x => x.Comentarios);
        }
    }
}
