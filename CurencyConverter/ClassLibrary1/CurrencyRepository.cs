using ApplicationCore.Entities;
using AutoMapper;
using Domain.Interfaces;
using NbyClient.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace NbyClient
{
    public class CurrencyRepository : ICurrencyRepository
    {
        const string URL = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=20190821&json";

        private IConfigurationProvider _mapperConfig;
        private IMapper _mapper;

        public CurrencyRepository()
        {
            InitMapper();
        }
        public Currency GetByAbreviation(string abreviation)
        {
            return ListAll().First(c => c.Abreviation == abreviation);
        }

        public Currency GetById(int id)
        {
            return ListAll().First(c => c.Id == id);
        }

        public IEnumerable<Currency> ListAll()
        {
            string response = "";
            using (WebClient wc = new WebClient())
            {
                response = Encoding.UTF8.GetString(wc.DownloadData(URL));
            }
            var result = JsonConvert.DeserializeObject<List<NbyModel>>(response);
            List<Currency> list = new List<Currency>();
            
            foreach(var c in result)
            {
                list.Add(_mapper.Map<Currency>(c));
            }
            return list;
        }
        
        private void InitMapper()
        {
            if (_mapper == null)
            {
                _mapperConfig = new MapperConfiguration(cfg =>
                       cfg.CreateMap<NbyModel, Currency>()
                           .ForMember(dest => dest.Id,
                               opt => opt.MapFrom(src => src.r030))
                           .ForMember(dest => dest.Name,
                               opt => opt.MapFrom(src => src.txt))
                           .ForMember(dest => dest.Abreviation,
                               opt => opt.MapFrom(src => src.cc))
                           .ForMember(dest => dest.SaleRate,
                               opt => opt.MapFrom(src => src.rate))
                       );
                _mapper = _mapperConfig.CreateMapper();
            }
        }
    }
}
