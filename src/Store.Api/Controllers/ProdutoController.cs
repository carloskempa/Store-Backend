using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Api.Controllers.Base;
using Store.Api.Models;
using Store.Catalogo.Application.Services;
using Store.Catalogo.Application.ViewModels;
using Store.Core.Communication.Mediator;
using Store.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService, INotificationHandler<DomainNotification> notifications,
           IMediatorHandler mediatorHandler, IMapper mapper) : base(notifications, mediatorHandler, mapper)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("vitrine")]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> Index()
        {
            return Ok(await _produtoAppService.ObterTodos());
        }

        [HttpGet]
        [Route("produto-detalhe/{id}")]
        public async Task<ActionResult<ProdutoViewModel>> ProdutoDetalhe(Guid id)
        {
            return Ok(await _produtoAppService.ObterPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<RetornoPadrao<ProdutoViewModel>>> Cadastrar([FromBody] ProdutoViewModel model)
        {
            try
            {
                await _produtoAppService.AdicionarProduto(model);
                return Success(model);
            }
            catch (Exception ex)
            {
                return Error<ProdutoViewModel>(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<RetornoPadrao<ProdutoViewModel>>> Atualizar([FromBody] ProdutoViewModel model)
        {
            try
            {
                await _produtoAppService.AtualizarProduto(model);
                return Success(model);
            }
            catch (Exception ex)
            {
                return Error<ProdutoViewModel>(ex.Message);
            }
        }

    }
}
