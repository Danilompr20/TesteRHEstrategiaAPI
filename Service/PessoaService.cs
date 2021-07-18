using AutoMapper;
using Domain.Entity;
using Repository;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
     public class PessoaService
    {
        private readonly IPessoaRepository _repository;
       
        private readonly IMapper _mapper;
        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _repository = pessoaRepository;
            _mapper = mapper;
                 
        }
        public PessoaViewModel Add(PessoaViewModel pessoaViewModel)
        {
            try
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaViewModel);
                _repository.Add(pessoa);
                var retorno = _repository.GetById(pessoaViewModel.Id);
                return _mapper.Map<PessoaViewModel>(retorno);
            }
            catch (Exception ex )
            {

                throw new Exception (ex.Message);
            }
        }
        public PessoaViewModel Update(int id, PessoaViewModel pessoaViewModel)
        {
            try
            {
                var pessoa = _repository.GetById(id);
                if (pessoa is null)
                {
                    return null;
                }
                else
                {
                    var pessoaEntity = _mapper.Map<Pessoa>(pessoaViewModel);
                    _repository.Update(pessoaEntity);
                }

                var retorno = _repository.GetById(pessoaViewModel.Id);
                return _mapper.Map<PessoaViewModel>(retorno);
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(int id)
        {
            try
            {
                var pessoa = _repository.GetById(id);
                if (pessoa == null)
                {
                    throw new Exception("Pessoa não encontrada");
                }
                else
                {
                    _repository.Delete(pessoa);
                }
            }
            catch (Exception ex )
            {

                throw new Exception(ex.Message);
            }
        }

        public PessoaViewModel GetById(int id)
        {
            try
            {
                var pessoa = _repository.GetById(id);
                if (pessoa is null)
                {
                    return null;
                }
                var viewModel = _mapper.Map<PessoaViewModel>(pessoa);
                return viewModel;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PessoaViewModel> Get()
        {
            try
            {
                var pessoas = _repository.Get();
                if (pessoas is null)
                {
                    return null;
                }
                else
                {
                    var viewModels = new List<PessoaViewModel>();
                    foreach (var item in pessoas)
                    {
                        var viewModel = _mapper.Map<PessoaViewModel>(item);
                        viewModels.Add(viewModel);
                    }
                    return (viewModels);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
