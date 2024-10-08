﻿using ArcelikWebApi.Data;
using ArcelikWebApi.Models;
using ArcelikWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArcelikWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAppController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IBlobService _blobService;

        public CreateAppController(ApplicationDbContext applicationDbContext, IBlobService BlobService)
        {
            _applicationDbContext = applicationDbContext;
            _blobService = BlobService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var aiApps = await _applicationDbContext.AiApplications
                .ToListAsync();

            return new JsonResult(aiApps);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddAiAppViewModel formData)
        {
            // Retrieve user email from context.Items
            var userEmailFromContext = HttpContext.Items["UserEmail"] as string;

            if (ModelState.IsValid)
            {
                //Additional server-side validation for the date and time
                if (!IsValidDateTime(formData.Date))
                    {
                        // Return a response indicating invalid data
                        return BadRequest(new { success = false, message = "Invalid date and time value." });
                    }

                var aiApplication = new AiApplication()
                {
                    id = Guid.NewGuid(),
                    AppName = formData.AppName,
                    WelcomeMessage = formData.WelcomeMessage,
                    SystemPrompt = formData.SystemPrompt,
                    SelectedModel = formData.SelectedModel,
                    UseKnowledgebase = formData.UseKnowledgebase,
                    EnableUploadPdfFile = formData.Enable_Upload_Pdf_File,
                    ConversationRetentionPeriod = formData.ConversationRetentionPeriod,
                    ModalTemperature = formData.ModalTemperature,
                    Pdfs_Urls = string.Empty,
                    Email = userEmailFromContext,
                    Date = formData.Date
                };

                _applicationDbContext.AiApplications.Add(aiApplication);
                if(formData.Pdfs != null)
                {
                    var blobUrls = new List<string>();

                    foreach (var pdfFile in formData.Pdfs)
                    {
                        string blobUrl = await _blobService.Upload(pdfFile, "files");
                        blobUrls.Add(blobUrl);
                    }
                aiApplication.Pdfs_Urls = string.Join(",", blobUrls);
                }



                _applicationDbContext.SaveChanges();



                return Ok(new { success = true, message = "Form data received successfully", data = aiApplication });
            }

            return Ok(new { success = false, message = "Form data couldnt received" });
        }

        private bool IsValidDateTime(DateTime dateTime)
        {
            // Example validation: Check if the date is not in the past
            return dateTime > DateTime.UtcNow;
        }

    }
}