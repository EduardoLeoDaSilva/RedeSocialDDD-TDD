using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RedeSocial_DDD_TDD.Dominio.Entidades;

namespace RedeSocial_DDD_TDD.Infra.Dados.EntityConfigs
{
    public class LikePostagemEntityConfig: IEntityTypeConfiguration<LikePostagem>
    {
        public void Configure(EntityTypeBuilder<LikePostagem> builder)
        {
            builder.HasKey(x => new {x.LikeId, x.PostagemId});
            builder.HasOne(x => x.Like).WithMany(x => x.LikePostagens).HasForeignKey(x => x.LikeId);
            builder.HasOne(x => x.Postagem).WithMany(x => x.LikePostagens).HasForeignKey(x => x.PostagemId);
        }
    }
}
