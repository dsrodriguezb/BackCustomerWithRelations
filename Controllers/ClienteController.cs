using BackCustomerWithRelations.Context;
using BackCustomerWithRelations.DTOs;
using BackCustomerWithRelations.Models;
using BackCustomerWithRelations.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Collections.Specialized;

namespace BackCustomerWithRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //Es variable de solo lectura
        //private readonly AppDbContext _appDbContext;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listClientes = await _clienteRepository.GetAll();

                var clientesDto = listClientes.Select(cliente => new ClienteDTO
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Pais = cliente.MstPais.Pais,
                    Ciudad = cliente.MstCiudad.Ciudad,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Email = cliente.Email,
                    Active = cliente.Active
                    // Agrega otros campos que desees mostrar
                }).ToList();

                return Ok(clientesDto);
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetOne(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                var clienteDto = new ClienteDTO
                {
                    Id = cliente.Id,
                    Nombre = cliente.Nombre,
                    Apellido = cliente.Apellido,
                    Pais = cliente.MstPais.Pais,
                    Ciudad = cliente.MstCiudad.Ciudad,
                    Direccion = cliente.Direccion,
                    Telefono = cliente.Telefono,
                    FechaNacimiento = cliente.FechaNacimiento,
                    Email = cliente.Email,
                    Active = cliente.Active
                    // Agrega otros campos que desees mostrar
                };

                return Ok(clienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(Cliente cliente)
        {
            try
            {
                cliente.FechaCreacion = DateTime.Now;

                var clienteItem = await _clienteRepository.PostCliente(cliente);

                var clienteEncontrado = await _clienteRepository.GetOne(clienteItem.Id);

                var clienteDto = new ClienteDTO
                {
                    Id = clienteEncontrado.Id,
                    Nombre = clienteEncontrado.Nombre,
                    Apellido = clienteEncontrado.Apellido,
                    Pais = clienteEncontrado.MstPais.Pais,
                    Ciudad = clienteEncontrado.MstCiudad.Ciudad,
                    Direccion = clienteEncontrado.Direccion,
                    Telefono = clienteEncontrado.Telefono,
                    FechaNacimiento = clienteEncontrado.FechaNacimiento,
                    Email = clienteEncontrado.Email,
                    Active = clienteEncontrado.Active
                    // Agrega otros campos que desees mostrar
                };

                return CreatedAtAction("GetOne", new { id = clienteDto.Id }, clienteDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            try
            {
                if (id != cliente.Id)
                {
                    return BadRequest();
                }

                //var clienteItem = await _clienteRepository.GetOne(id);
                //if (clienteItem == null)
                //{
                //    return NotFound();
                //}

                await _clienteRepository.PutMascota(cliente);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetOne(id);
                if (cliente == null)
                {
                    return NotFound();
                }

                await _clienteRepository.Delete(cliente);
                
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
