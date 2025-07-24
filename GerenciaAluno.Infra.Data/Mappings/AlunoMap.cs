using GerenciaAluno.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Infra.Data.Mappings
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(a => a.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.DataNascimento)
                .IsRequired();

            builder.OwnsOne(a => a.Cpf, cpf =>
            {
                cpf.Property(c => c.Numero)
                    .HasColumnName("Cpf")
                    .IsRequired()
                    .HasMaxLength(14);
            });

            builder.HasMany(a => a.Notas)
                .WithOne(n => n.Aluno)
                .HasForeignKey(n => n.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}