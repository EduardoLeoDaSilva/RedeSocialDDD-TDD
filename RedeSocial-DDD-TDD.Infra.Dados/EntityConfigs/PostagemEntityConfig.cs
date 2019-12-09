using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Infra.Dados.EntityConfigs
{
    public class PostagemEntityConfig: IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Usuario);
            builder.HasMany(x => x.LikePostagens).WithOne(x => x.Postagem);
            builder.HasMany(x => x.Comentarios).WithOne(x => x.Postagem);

            builder.ToTable("Postagens");

        }
    }
}
