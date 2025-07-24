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
    public class ProfessorMap : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.DataNascimento)
                .IsRequired();

            builder.OwnsOne(p => p.Cpf, cpf =>
            {
                cpf.Property(c => c.Numero)
                    .HasColumnName("Cpf")
                    .IsRequired()
                    .HasMaxLength(14);
            });

            builder.HasMany(p => p.NotasLançadas)
                .WithOne(n => n.Professor)
                .HasForeignKey(n => n.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}