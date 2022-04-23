﻿using System;
using PTC.Domain.Entities;
using PTC.Domain.Interfaces.Repository;
using PTC.Domain.Interfaces.Services;

namespace PTC.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Alterar(Endereco obj)
        {
            _enderecoRepository.Alterar(obj);
        }

        public void Deletar(Endereco obj)
        {
            _enderecoRepository.Deletar(obj);
        }

        public int Inserir(Endereco obj)
        {
            return _enderecoRepository.Inserir(obj);
        }

        public Endereco ObterPorIdProprietario(int id)
        {
            throw new NotImplementedException();
            //return _enderecoRepository.ObterPorIdProprietario(id);
        }
    }
}
