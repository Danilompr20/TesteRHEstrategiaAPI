using AutoMapper;
using Domain.Entity;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Util
{
     public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();

        }
    }
}
