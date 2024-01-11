using Agency.Business.Helpers;
using Agency.Business.Services.Interfaces;
using Agency.Business.ViewModels.PortfolioVms;
using Agency.Core.Common;
using Agency.DAL.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Business.Services.Implementations
{
	public class PortfolioService : IPortfolioService
	{
		private readonly IPortfolioRepository _repository;
		private readonly IMapper _mapper;
		IWebHostEnvironment _env;
		public PortfolioService(IPortfolioRepository repository, IMapper mapper,IWebHostEnvironment env)
		{
			_repository = repository;
			_mapper = mapper;
			_env = env;
		}
		public async Task<List<PortfolioGetVm>> GetAllAsync()
		{
			IQueryable<Portfolio> portfolios = await _repository.GetAllAsync();
			List<PortfolioGetVm> result = new List<PortfolioGetVm>();
			foreach (var portfolio in portfolios)
			{
				PortfolioGetVm vm = _mapper.Map<PortfolioGetVm>(portfolio);
				result.Add(vm);
			}
			return result;
		}
		public async Task<PortfolioGetVm> GetByIdAsync(int id)
		{
			Portfolio portfolio = await _repository.GetByIdAsync(id);
			PortfolioGetVm portfolioVm = _mapper.Map<PortfolioGetVm>(portfolio);
			return portfolioVm;
		}
		public async Task CreateAsync(PortfolioCreateVm entity)
		{
			if (entity == null)
			{
				throw new Exception(message: "Portfolio null ola bilmez");
			}
			if (!entity.ImageFile.ContentType.Contains("image"))
			{
				throw new Exception(message:"Yanlis Format");
			}
			if (entity.ImageFile.Length > 3170304)
			{
				throw new Exception(message:"Sekilin Olcusu 3 mb-dan cox olmamalidir");
			}
			entity.ImageUrl = entity.ImageFile.Upload(_env.WebRootPath, @"\Upload\PortfolioImage\");
			Portfolio portfolio = _mapper.Map<Portfolio>(entity);
			await _repository.Create(portfolio);
			await _repository.SaveChangesAsync();
		}
		public async Task UpdateAsync(PortfolioUpdateVm entity)
		{
			if (entity == null)
			{
				throw new Exception(message: "Portfolio null ola bilmez");
			}
			if (!entity.ImageFile.ContentType.Contains("image"))
			{
				throw new Exception(message: "Yanlis Format");
			}
			if (entity.ImageFile.Length > 3170304)
			{
				throw new Exception(message: "Sekilin Olcusu 3 mb-dan cox olmamalidir");
			}
			entity.ImageUrl = entity.ImageFile.Upload(_env.WebRootPath, @"\Upload\PortfolioImage\");

			Portfolio oldPortfolio = await _repository.GetByIdAsync(entity.Id);

			FileManager.DeleteFile(oldPortfolio.ImageUrl, _env.WebRootPath, @"\Upload\PortfolioImage\");

			_mapper.Map(oldPortfolio, entity);
			await _repository.Update(oldPortfolio);
			await _repository.SaveChangesAsync();
		}
		public async Task DeleteAsync(int id)
		{
			Portfolio portfolio = await _repository.GetByIdAsync(id);
			portfolio.IsDeleted = true;
			await _repository.Delete(portfolio);
			await _repository.SaveChangesAsync();
		}
	}
}

