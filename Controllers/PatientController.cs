﻿using ClinicManagementMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public PatientController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient("APIClient");
            List<Patient> patients = null;

            HttpResponseMessage response = await client.GetAsync("api/patients");

            if (response.IsSuccessStatusCode)
            {
                patients = await response.Content.ReadFromJsonAsync<List<Patient>>();
            }

            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.PostAsJsonAsync("api/patients", patient);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível adicionar o paciente");
                }
            }

            return View(patient);
        }

        [HttpGet("patients/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.DeleteAsync("api/patients/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível excluir o paciente");
                }
            }

            return View();
        }

        [HttpGet("patients/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient("APIClient");
            HttpResponseMessage response = await client.GetAsync("api/patients/" + id);
            Patient patient = null;

            if (response.IsSuccessStatusCode)
            {
                patient = await response.Content.ReadFromJsonAsync<Patient>();
            }

            return View(patient);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Update(int id, Patient patient)
        {
            if (ModelState.IsValid)
            {
                var client = _clientFactory.CreateClient("APIClient");
                HttpResponseMessage response = await client.PutAsJsonAsync("api/patients/" + id, patient);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Não foi possível editar o paciente");
                }
            }

            return View(patient);
        }
    }
}
