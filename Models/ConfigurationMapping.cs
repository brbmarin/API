using AutoMapper;
using Microsoft.EntityFrameworkCore;
using newWebAPI.Models.DTOs;
namespace newWebAPI.Models;

public class ConfigurationMapping : Profile 
{
   public ConfigurationMapping()
   {
      CreateMap<Book, BookUpdateDTO>().ReverseMap();
   }
}