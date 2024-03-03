using jwtService;
using ProjectFinancas.Controllers.Dtos;
using System;
using System.Collections.Generic;

namespace ProjectFinancas.Domain.UseCase.EmailAuth
{
    public class EmailAuthUseCase
    {
        private readonly Dictionary<string, string> codigosPendentes;
        private readonly JwtService _jwtService;

        public EmailAuthUseCase(JwtService jwtService)
        {
            codigosPendentes = new Dictionary<string, string>();
            _jwtService = jwtService;
        }

        public string ValidarEmail(CodigoDto codigoDto)
        {
            if (codigosPendentes.TryGetValue(codigoDto.Email, out var codigoArmazenado))
            {
                if (codigoDto.Codigo == codigoArmazenado)
                {
                    
                    return _jwtService.CreateToken(codigoDto);
                }
                else
                {

                    throw new CustomError("Código invalido");

                }
            }
            throw new CustomError("Código não encontrado.");
        }

        public void GerarCodigo(string email, string codigo)
        {
            codigosPendentes.Add(email, codigo);
        }
    }
}