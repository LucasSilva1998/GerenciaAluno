using GerenciaAluno.Domain.Entities;
using GerenciaAluno.Domain.Interfaces.Core;
using GerenciaAluno.Domain.Interfaces.Repository;
using GerenciaAluno.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAluno.Domain.Services
{
    public class CadastroDomainService : ICadastroDomainService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IProfessorRepository _professorRepository;
        private readonly ICadastroDomainService _cadastroDomainService;
        private readonly IUnitOfWork _unitOfWork;

        public CadastroDomainService(IAlunoRepository alunoRepository, IProfessorRepository professorRepository, ICadastroDomainService cadastroDomainService, IUnitOfWork unitOfWork)
        {
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _cadastroDomainService = cadastroDomainService;
            _unitOfWork = unitOfWork;
        }

        public async Task CadastrarAlunoAsync(Aluno aluno)
        {            
            if (await _alunoRepository.ExisteCpfAsync(aluno.Cpf.Numero))
                throw new Exception("CPF já cadastrado para um paciente.");             
      
            await _alunoRepository.AdicionarAsync(aluno);
            await _unitOfWork.CommitAsync();
        }

        public async Task CadastrarProfessorAsync(Professor professor)
        {
            if (await _professorRepository.ExisteCpfAsync(professor.Cpf.Numero))
                throw new Exception("CPF já cadastrado para um paciente.");

            await _professorRepository.AdicionarAsync(professor);
            await _unitOfWork.CommitAsync();
        }
    }
}