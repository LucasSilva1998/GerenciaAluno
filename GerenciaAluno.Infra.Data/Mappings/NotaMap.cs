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
    public class NotaMap : IEntityTypeConfiguration<Nota>
    {
        public void Configure(EntityTypeBuilder<Nota> builder)
        {
            builder.ToTable("Notas");

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                .ValueGeneratedOnAdd(); 

            builder.Property(n => n.AlunoId)
                .IsRequired();

            builder.Property(n => n.ProfessorId)
                .IsRequired();

            builder.Property(n => n.Disciplina)
                .IsRequired()
                .HasConversion<String>(); 

            builder.Property(n => n.Valor)
                .IsRequired()
                .HasColumnType("decimal(5,2)"); 

            builder.Property(n => n.Status)
                .IsRequired()
                .HasConversion<String>();

            builder.Property(n => n.DataLancamento)
                .IsRequired();

            builder.HasOne(n => n.Aluno)
                .WithMany(a => a.Notas)
                .HasForeignKey(n => n.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(n => n.Professor)
                .WithMany(p => p.NotasLançadas)
                .HasForeignKey(n => n.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}